import pygame, math, re

# =====================
# Initialization
# =====================
pygame.init()
WIDTH, HEIGHT = 2560, 1440
SIDEBAR = 400
screen = pygame.display.set_mode((WIDTH, HEIGHT))
pygame.display.set_caption("Python Map Editor")
clock = pygame.time.Clock()
font = pygame.font.SysFont("consolas", 18)
FOV = 500

# =====================
# Color Map 256
# =====================
ColorMap256 = {
    "Black": (0,0,0), "Maroon": (128,0,0), "DarkGreen": (0,128,0), "Olive": (128,128,0),
    "Navy": (0,0,128), "Purple": (128,0,128), "Teal": (0,128,128), "Silver": (192,192,192),
    "Grey": (128,128,128), "Red": (255,0,0), "Lime": (0,255,0), "Yellow": (255,255,0),
    "Blue": (0,0,255), "Fuchsia": (255,0,255), "Aqua": (0,255,255), "White": (255,255,255)
}
for i in range(16, 232):
    idx = i - 16
    r = idx // 36; g = (idx % 36) // 6; b = idx % 6
    ColorMap256[f"Color{i}"] = (
        0 if r==0 else 55+r*40,
        0 if g==0 else 55+g*40,
        0 if b==0 else 55+b*40
    )
for i in range(232, 256):
    gray = 8 + (i-232)*10
    ColorMap256[f"Gray{i}"] = (gray, gray, gray)

# =====================
# Classes
# =====================
class SceneObject:
    def __init__(self, mesh, x=0, y=0, z=5,
                 rotX=0, rotY=0, rotZ=0,
                 sx=1, sy=1, sz=1,
                 rigid=False, mass=1, dynamic=False):
        self.mesh = mesh
        self.x = x; self.y = y; self.z = z
        self.rotX = rotX; self.rotY = rotY; self.rotZ = rotZ
        self.sx = sx; self.sy = sy; self.sz = sz
        self.rigid = rigid; self.mass = mass
        self.dynamic = dynamic
        self.color = (200,200,200)

class ColorPalette:
    def __init__(self, x, y, w, h, colors, cols=16, cell_size=20, padding=2):
        self.x = x; self.y = y; self.w = w; self.h = h
        self.colors = colors
        self.cols = cols; self.cell_size = cell_size; self.padding = padding
        self.selected_name = None
        self.color_names = list(colors.keys())
    def draw(self, surf):
        for idx, name in enumerate(self.color_names):
            row = idx // self.cols; col = idx % self.cols
            rx = self.x + col*(self.cell_size+self.padding)
            ry = self.y + row*(self.cell_size+self.padding)
            pygame.draw.rect(surf, self.colors[name], (rx, ry, self.cell_size, self.cell_size))
            if self.selected_name == name:
                pygame.draw.rect(surf, (255,255,255), (rx, ry, self.cell_size, self.cell_size), 2)
    def event(self, ev):
        if ev.type == pygame.MOUSEBUTTONDOWN:
            mx,my = ev.pos
            for idx, name in enumerate(self.color_names):
                row = idx // self.cols; col = idx % self.cols
                rx = self.x + col*(self.cell_size+self.padding)
                ry = self.y + row*(self.cell_size+self.padding)
                if pygame.Rect(rx, ry, self.cell_size, self.cell_size).collidepoint(mx,my):
                    self.selected_name = name
                    return name
        return None

class InputField:
    def __init__(self, label, value, y):
        self.label = label
        self.value = str(value)
        self.rect = pygame.Rect(WIDTH - SIDEBAR + 20, y, 260, 28)
        self.active = False
    def draw(self):
        color = (255,200,80) if self.active else (90,90,100)
        pygame.draw.rect(screen, color, self.rect, 2)
        text = font.render(f"{self.label}: {self.value}", True, (230,230,230))
        screen.blit(text, (self.rect.x+5, self.rect.y+5))
    def event(self, event):
        if event.type == pygame.MOUSEBUTTONDOWN:
            self.active = self.rect.collidepoint(event.pos)
        if event.type == pygame.KEYDOWN and self.active:
            if event.key == pygame.K_BACKSPACE:
                self.value = self.value[:-1]
            elif event.key == pygame.K_RETURN:
                self.active = False
            else:
                if event.unicode in "0123456789.-":
                    self.value += event.unicode

class CheckBox:
    def __init__(self, label, value, y):
        self.label = label
        self.value = value
        self.box = pygame.Rect(WIDTH-SIDEBAR+20, y, 20, 20)
    def draw(self):
        pygame.draw.rect(screen, (200,200,200), self.box, 2)
        if self.value:
            pygame.draw.line(screen, (200,200,200), (self.box.left,self.box.top), (self.box.right,self.box.bottom), 2)
            pygame.draw.line(screen, (200,200,200), (self.box.left,self.box.bottom), (self.box.right,self.box.top), 2)
        text = font.render(self.label, True, (220,220,220))
        screen.blit(text, (self.box.right+10, self.box.y))
    def event(self, event):
        if event.type == pygame.MOUSEBUTTONDOWN and self.box.collidepoint(event.pos):
            self.value = not self.value

# =====================
# Camera functions
# =====================
cam_x = 0; cam_y = 0; cam_z = -10
yaw = 0; pitch = 0
def get_camera_vectors():
    fx = math.sin(yaw); fy = 0; fz = math.cos(yaw)
    rx = math.cos(yaw); rz = -math.sin(yaw)
    return (fx, fy, fz), (rx, 0, rz)
def rotate(x, y, z):
    cx = math.cos(yaw); sx = math.sin(yaw)
    dx = x*cx - z*sx; dz = x*sx + z*cx; x, z = dx, dz
    cp = math.cos(pitch); sp = math.sin(pitch)
    dy = y*cp - z*sp; dz = y*sp + z*cp
    return x, dy, dz
def project(v):
    x, y, z = v
    x -= cam_x; y -= cam_y; z -= cam_z
    x, y, z = rotate(x, y, z)
    if z <= 0.1: z = 0.1
    px = WIDTH/2 + x/z*FOV
    py = HEIGHT/2 - y/z*FOV
    return int(px), int(py)

# =====================
# Meshes
# =====================
cube_v = [(-1,-1,-1),(1,-1,-1),(1,1,-1),(-1,1,-1),(-1,-1,1),(1,-1,1),(1,1,1),(-1,1,1)]
cube_e = [(0,1),(1,2),(2,3),(3,0),(4,5),(5,6),(6,7),(7,4),(0,4),(1,5),(2,6),(3,7)]

# =====================
# Scene helper functions
# =====================
def draw_obj(o, is_selected=False):
    if o.mesh == "Cube":
        v, e = cube_v, cube_e
    elif o.mesh == "Pyramid":
        v = [(-1,-1,-1),(1,-1,-1),(1,-1,1),(-1,-1,1),(0,1,0)]
        e = [(0,1),(1,2),(2,3),(3,0),(0,4),(1,4),(2,4),(3,4)]
    elif o.mesh == "Plane":
        v = [(-1,0,-1),(1,0,-1),(1,0,1),(-1,0,1)]
        e = [(0,1),(1,2),(2,3),(3,0)]
    elif o.mesh == "Sphere":
        v = []; e = []
        segments = 12
        for i in range(segments):
            a = 2*math.pi*i/segments
            v.append((math.cos(a), 0, math.sin(a)))
        for i in range(segments):
            e.append((i, (i+1)%segments))
    else:
        v, e = cube_v, cube_e

    verts = []
    for p in v:
        x = p[0]*o.sx; y = p[1]*o.sy; z = p[2]*o.sz
        rx = math.radians(o.rotX); ry = math.radians(o.rotY); rz = math.radians(o.rotZ)
        y,z = y*math.cos(rx)-z*math.sin(rx), y*math.sin(rx)+z*math.cos(rx)
        x,z = x*math.cos(ry)+z*math.sin(ry), -x*math.sin(ry)+z*math.cos(ry)
        x,y = x*math.cos(rz)-y*math.sin(rz), x*math.sin(rz)+y*math.cos(rz)
        x += o.x; y += o.y; z += o.z
        verts.append(project((x,y,z)))
    for edge in e:
        pygame.draw.line(screen, o.color, verts[edge[0]], verts[edge[1]], 1)

    if is_selected:
        xs = [v[0] for v in verts]
        ys = [v[1] for v in verts]
        min_x, max_x = min(xs), max(xs)
        min_y, max_y = min(ys), max(ys)
        pygame.draw.rect(screen, (255,255,255), (min_x, min_y, max_x-min_x, max_y-min_y), 2)

# =====================
# Sidebar
# =====================
def build_sidebar(obj):
    return [
        InputField("posX", obj.x, 40), InputField("posY", obj.y, 70), InputField("posZ", obj.z, 100),
        InputField("rotX", obj.rotX, 150), InputField("rotY", obj.rotY, 180), InputField("rotZ", obj.rotZ, 210),
        InputField("scaleX", obj.sx, 260), InputField("scaleY", obj.sy, 290), InputField("scaleZ", obj.sz, 320),
        InputField("mass", obj.mass, 380),
        CheckBox("RigidBody", obj.rigid, 430),
        CheckBox("Dynamic", obj.dynamic, 460)
    ]

def apply_fields(obj, fields):
    try:
        obj.x = float(fields[0].value); obj.y = float(fields[1].value); obj.z = float(fields[2].value)
        obj.rotX = float(fields[3].value); obj.rotY = float(fields[4].value); obj.rotZ = float(fields[5].value)
        obj.sx = float(fields[6].value); obj.sy = float(fields[7].value); obj.sz = float(fields[8].value)
        obj.mass = float(fields[9].value)
        obj.rigid = fields[10].value
        obj.dynamic = fields[11].value
    except: pass

def draw_sidebar(obj, fields):
    pygame.draw.rect(screen, (45,45,55), (WIDTH-SIDEBAR,0,SIDEBAR,HEIGHT))
    title = font.render("Object Properties", True, (255,255,255))
    screen.blit(title, (WIDTH-SIDEBAR+20,10))
    mesh = font.render(f"Mesh: {obj.mesh}", True, (220,220,220))
    screen.blit(mesh, (WIDTH-SIDEBAR+20,470))
    for f in fields: f.draw()

# =====================
# Object picking
# =====================
def object_at_mouse(scene, mouse_pos):
    mx, my = mouse_pos
    for idx, o in enumerate(scene):
        px, py = project((o.x, o.y, o.z))
        screen_size = max(o.sx, o.sy, o.sz) * 50
        rect = pygame.Rect(px-screen_size//2, py-screen_size//2, screen_size, screen_size)
        if rect.collidepoint(mx, my):
            return idx
    return None


def export_scene(scene, filename="scene_export.txt"):
    standard_colors = ["Black","Maroon","DarkGreen","Olive","Navy","Purple","Teal","Silver",
                       "Grey","Red","Lime","Yellow","Blue","Fuchsia","Aqua","White"]
    with open(filename,"w") as f:
        for o in scene:
            # Color
            color_name = None
            for idx,(name,rgb) in enumerate(ColorMap256.items()):
                if rgb == o.color:
                    color_name = name if name in standard_colors else f"Color.Color{idx}"
                    break
            if color_name is None: color_name = "Color.ColorUnknown"

            # Mesh
            mesh_map = {"Cube":"Mesh.Cube()", "Pyramid":"Mesh.Pyramid()", "Plane":"Mesh.Plane()", "Sphere":"Mesh.Sphere()"}
            mesh_cs = mesh_map.get(o.mesh, "Mesh.Unknown()")

            # Rigid & Mass
            rigid_str = "true" if o.rigid else "false"
            mass_str = f"{o.mass}f"

            # Rotations
            rotX_str = f"{o.rotX}*SceneObject.Deg(1)" if o.dynamic else str(o.rotX)
            rotY_str = f"{o.rotY}*SceneObject.Deg(1)" if o.dynamic else str(o.rotY)
            rotZ_str = f"{o.rotZ}*SceneObject.Deg(1)" if o.dynamic else str(o.rotZ)

            # Position & Scale
            x = round(o.x,2); y = round(o.y,2); z = round(o.z,2)
            sx = round(o.sx,2); sy = round(o.sy,2); sz = round(o.sz,2)

            line = (
                f"new SceneObject({mesh_cs}, x:{x}, y:{y}, z:{z}, color: {color_name}, "
                f"scaleX:{sx}f, scaleY:{sy}f, scaleZ:{sz}f, "
                f"rotX:{rotX_str}, rotY:{rotY_str}, rotZ:{rotZ_str}, "
                f"rigid:{rigid_str}, mass:{mass_str}),\n"
            )
            f.write(line)
    print(f"Scene exported to {filename}")

# =====================
# Scene loading (your regex loader)
# =====================
def load_scene_txt(filename="scene_export.txt"):
    scene = []
    pattern = re.compile(
        r"new SceneObject\(\s*(Mesh\.(\w+)\(\))\s*,\s*"
        r"x:\s*([-\d.]+)\s*,\s*y:\s*([-\d.]+)\s*,\s*z:\s*([-\d.]+)"
        r"(?:,\s*color:\s*Color\.(\w+))?"
        r"(?:,\s*scaleX:\s*([-\d.]+)f?,\s*scaleY:\s*([-\d.]+)f?,\s*scaleZ:\s*([-\d.]+)f?)?"
        r"(?:,\s*rotX:\s*([-\d.*SceneObjectDeg1]+))?"
        r"(?:,\s*rotY:\s*([-\d.*SceneObjectDeg1]+))?"
        r"(?:,\s*rotZ:\s*([-\d.*SceneObjectDeg1]+))?"
        r"(?:,\s*rigid(?:Body)?:\s*(true|false))?"
        r"(?:,\s*mass:\s*([-\d.]+)f?)?"
        r"\)"
    )

    for line in open(filename, "r"):
        match = pattern.search(line)
        if match:
            mesh_full, mesh_name, x, y, z, color, sx, sy, sz, rotX, rotY, rotZ, rigid, mass = match.groups()
            x, y, z = float(x), float(y), float(z)
            sx = float(sx) if sx else 1
            sy = float(sy) if sy else 1
            sz = float(sz) if sz else 1
            rotX = rotX.strip() if rotX else "0"
            rotY = rotY.strip() if rotY else "0"
            rotZ = rotZ.strip() if rotZ else "0"
            dynamic = False
            if "*SceneObject.Deg(1)" in rotX: rotX = rotX.replace("*SceneObject.Deg(1)",""); dynamic = True
            if "*SceneObject.Deg(1)" in rotY: rotY = rotY.replace("*SceneObject.Deg(1)",""); dynamic = True
            if "*SceneObject.Deg(1)" in rotZ: rotZ = rotZ.replace("*SceneObject.Deg(1)",""); dynamic = True
            rotX = float(rotX); rotY = float(rotY); rotZ = float(rotZ)
            rigid = True if rigid=="true" else False
            mass = float(mass) if mass else 1
            color_name = color if color else "White"
            color_rgb = ColorMap256.get(color_name, (200,200,200))
            obj = SceneObject(
                mesh_name, x=x, y=y, z=z,
                sx=sx, sy=sy, sz=sz,
                rotX=rotX, rotY=rotY, rotZ=rotZ,
                rigid=rigid, mass=mass,
                dynamic=dynamic
            )
            obj.color = color_rgb
            scene.append(obj)
    return scene

# =====================
# Initialize
# =====================
scene = load_scene_txt()
selected = 0
fields = build_sidebar(scene[selected]) if scene else []

palette = ColorPalette(WIDTH-SIDEBAR+20, 500, SIDEBAR-40, 250, ColorMap256, cols=16)

pygame.mouse.set_visible(True)
pygame.event.set_grab(False)

# =====================
# Main Loop
# =====================
running = True
while running:
    dt = clock.tick(60)/1000
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        # Handle sidebar fields
        for f in fields:
            if hasattr(f,"event"): f.event(event)

        # Handle color palette
        selected_color_name = palette.event(event)
        if selected_color_name and scene:
            scene[selected].color = ColorMap256[selected_color_name]

        # Object selection by click
        if event.type == pygame.MOUSEBUTTONDOWN and event.button == 1:
            clicked_idx = object_at_mouse(scene, event.pos)
            if clicked_idx is not None:
                selected = clicked_idx
                fields = build_sidebar(scene[selected])

        # Keyboard shortcuts
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_t:
                scene.append(SceneObject("Cube"))
                selected = len(scene)-1
                fields = build_sidebar(scene[selected])
            elif event.key == pygame.K_z:
                scene.append(SceneObject("Pyramid"))
                selected = len(scene)-1
                fields = build_sidebar(scene[selected])
            elif event.key == pygame.K_u:
                scene.append(SceneObject("Plane"))
                selected = len(scene)-1
                fields = build_sidebar(scene[selected])
            elif event.key == pygame.K_i:
                scene.append(SceneObject("Sphere"))
                selected = len(scene)-1
                fields = build_sidebar(scene[selected])
            elif event.key == pygame.K_TAB and scene:
                selected = (selected + 1) % len(scene)
                fields = build_sidebar(scene[selected])
            elif event.key == pygame.K_p and scene:
                export_scene(scene)
            elif event.key == pygame.K_j and scene:
    # Remove the currently selected object
                scene.pop(selected)
    # Adjust selected index
                if scene:
                    selected = max(0, selected-1)
                    fields = build_sidebar(scene[selected])
                else:
                    selected = 0
                    fields = []

    # Camera movement
    if pygame.mouse.get_pressed()[2]:
        mx, my = pygame.mouse.get_rel()
        yaw += mx * 0.003; pitch += my * 0.003
    else:
        pygame.mouse.get_rel()
    keys = pygame.key.get_pressed()
    speed = 10*dt
    forward, right = get_camera_vectors()
    if keys[pygame.K_w]: cam_x += forward[0]*speed; cam_z += forward[2]*speed
    if keys[pygame.K_s]: cam_x -= forward[0]*speed; cam_z -= forward[2]*speed
    if keys[pygame.K_a]: cam_x -= right[0]*speed; cam_z -= right[2]*speed
    if keys[pygame.K_d]: cam_x += right[0]*speed; cam_z += right[2]*speed
    if keys[pygame.K_SPACE]: cam_y += speed
    if keys[pygame.K_LSHIFT] or keys[pygame.K_RSHIFT]: cam_y -= speed

    if scene: apply_fields(scene[selected], fields)

    # Draw
    screen.fill((20,20,30))
    for o in scene: draw_obj(o)
    if scene:
        draw_sidebar(scene[selected], fields)
        palette.draw(screen)

    pygame.display.flip()
pygame.quit()
