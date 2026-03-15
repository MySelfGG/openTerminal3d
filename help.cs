#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;




//Color enum 

public enum Color {
    Black = 0,Maroon = 1,DarkGreen = 2,Olive = 3,Navy = 4,Purple = 5,Teal = 6,Silver = 7,Grey = 8,Red = 9,
    Lime = 10,Yellow = 11,Blue = 12,Fuchsia = 13,Aqua = 14,White = 15,Black_00_16 = 16,Blue_07_17 = 17,Blue_13_18 = 18,Blue_20_19 = 19,
    Blue_26_20 = 20,Blue_33_21 = 21,Green_07_22 = 22,Cyan_13_23 = 23,Azure_20_24 = 24,Azure_26_25 = 25,Azure_33_26 = 26,Azure_40_27 = 27,Green_13_28 = 28,Cyan_20_29 = 29,
    Cyan_26_30 = 30,Azure_33_31 = 31,Azure_40_32 = 32,Azure_46_33 = 33,Green_20_34 = 34,Cyan_26_35 = 35,Cyan_33_36 = 36,Cyan_40_37 = 37,Azure_46_38 = 38,Azure_53_39 = 39,Green_26_40 = 40,
    Cyan_33_41 = 41,Cyan_40_42 = 42,Cyan_46_43 = 43,Cyan_53_44 = 44,Azure_59_45 = 45,Green_33_46 = 46,Cyan_40_47 = 47,Cyan_46_48 = 48,Cyan_53_49 = 49,Cyan_59_50 = 50,
    Cyan_66_51 = 51,Red_07_52 = 52,Magenta_13_53 = 53,Magenta_20_54 = 54,Magenta_26_55 = 55,Magenta_33_56 = 56,Magenta_40_57 = 57,Yellow_13_58 = 58,Grey_20_59 = 59,Cyan_26_60 = 60,
    Cyan_33_61 = 61,Cyan_40_62 = 62,Cyan_46_63 = 63,Yellow_20_64 = 64,Teal_26_65 = 65,Teal_33_66 = 66,Cyan_40_67 = 67,Cyan_46_68 = 68,Cyan_53_69 = 69,Yellow_26_70 = 70,
    Teal_33_71 = 71,Teal_40_72 = 72,Teal_46_73 = 73,Cyan_53_74 = 74,Cyan_59_75 = 75,Yellow_33_76 = 76,Teal_40_77 = 77,Teal_46_78 = 78,Teal_53_79 = 79,Teal_59_80 = 80,
    Cyan_66_81 = 81,Yellow_40_82 = 82,Teal_46_83 = 83,Teal_53_84 = 84,Teal_59_85 = 85,Teal_66_86 = 86,Teal_73_87 = 87,Red_13_88 = 88,Magenta_20_89 = 89,Magenta_26_90 = 90,
    Magenta_33_91 = 91, Magenta_40_92 = 92,Magenta_46_93 = 93,Orange_20_94 = 94,Pink_26_95 = 95,Pink_33_96 = 96,Purple_40_97 = 97,Purple_46_98 = 98,Purple_53_99 = 99,Yellow_26_100 = 100,
    Orange_33_101 = 101,Grey_40_102 = 102,Cyan_46_103 = 103,Cyan_53_104 = 104,Cyan_59_105 = 105,Yellow_33_106 = 106,Lime_40_107 = 107,Teal_46_108 = 108,Teal_53_109 = 109,Cyan_59_110 = 110,
    Cyan_66_111 = 111,Yellow_40_112 = 112,Lime_46_113 = 113,Teal_53_114 = 114,Teal_59_115 = 115,Teal_66_116 = 116,Cyan_73_117 = 117,Yellow_46_118 = 118,Lime_53_119 = 119,Teal_59_120 = 120,Teal_66_121 = 121,
    Teal_73_122 = 122,Teal_79_123 = 123,Red_20_124 = 124,Magenta_26_125 = 125,Magenta_33_126 = 126,Magenta_40_127 = 127,Magenta_46_128 = 128,Magenta_53_129 = 129,Orange_26_130 = 130,Pink_33_131 = 131,
    Pink_40_132 = 132, Pink_46_133 = 133,Purple_53_134 = 134,Purple_59_135 = 135,Orange_33_136 = 136,Orange_40_137 = 137,Pink_46_138 = 138,Pink_53_139 = 139,Purple_59_140 = 140,Purple_66_141 = 141,
    Yellow_40_142 = 142, Orange_46_143 = 143,Orange_53_144 = 144,Grey_59_145 = 145,Cyan_66_146 = 146,Cyan_73_147 = 147,Yellow_46_148 = 148,Lime_53_149 = 149,Lime_59_150 = 150,Teal_66_151 = 151,Teal_73_152 = 152,
    Cyan_79_153 = 153,Yellow_53_154 = 154, Lime_59_155 = 155,Lime_66_156 = 156,Teal_73_157 = 157,Teal_79_158 = 158,Teal_86_159 = 159,Red_26_160 = 160,Magenta_33_161 = 161,Magenta_40_162 = 162,Magenta_46_163 = 163,
    Magenta_53_164 = 164,Magenta_59_165 = 165,Orange_33_166 = 166,Pink_40_167 = 167,Pink_46_168 = 168,Pink_53_169 = 169,Pink_59_170 = 170,Purple_66_171 = 171,Orange_40_172 = 172,Orange_46_173 = 173,
    Pink_53_174 = 174,Pink_59_175 = 175,Pink_66_176 = 176,Purple_73_177 = 177,Orange_46_178 = 178,Orange_53_179 = 179,Orange_59_180 = 180,Pink_66_181 = 181,Pink_73_182 = 182,Purple_79_183 = 183,
    Yellow_53_184 = 184,Orange_59_185 = 185,Orange_66_186 = 186,Orange_73_187 = 187,Grey_79_188 = 188,Cyan_86_189 = 189,Yellow_59_190 = 190,Lime_66_191 = 191,Lime_73_192 = 192,Lime_79_193 = 193,
    Teal_86_194 = 194,Teal_92_195 = 195,Red_33_196 = 196,Magenta_40_197 = 197,Magenta_46_198 = 198,Magenta_53_199 = 199,Magenta_59_200 = 200,Magenta_66_201 = 201,Orange_40_202 = 202,Pink_46_203 = 203,
    Pink_53_204 = 204, Pink_59_205 = 205,Pink_66_206 = 206,Pink_73_207 = 207,Orange_46_208 = 208,Orange_53_209 = 209,Pink_59_210 = 210,Pink_66_211 = 211,Pink_73_212 = 212,Pink_79_213 = 213,
    Orange_53_214 = 214, Orange_59_215 = 215, Orange_66_216 = 216, Pink_73_217 = 217, Pink_79_218 = 218, Pink_86_219 = 219, Orange_59_220 = 220, Orange_66_221 = 221, Orange_73_222 = 222, Orange_79_223 = 223,
    Pink_86_224 = 224,Pink_92_225 = 225,Yellow_66_226 = 226,Orange_73_227 = 227,Orange_79_228 = 228,Orange_86_229 = 229,Orange_92_230 = 230,White_99_231 = 231,Grey_00_232 = 232,Grey_04_233 = 233,Grey_09_234 = 234,
    Grey_13_235 = 235,Grey_17_236 = 236,Grey_22_237 = 237,Grey_26_238 = 238,Grey_30_239 = 239,Grey_34_240 = 240,Grey_39_241 = 241,Grey_43_242 = 242,Grey_47_243 = 243,Grey_52_244 = 244,
    Grey_56_245 = 245,Grey_60_246 = 246, Grey_65_247 = 247,Grey_69_248 = 248,Grey_73_249 = 249,Grey_77_250 = 250,Grey_82_251 = 251,Grey_86_252 = 252,Grey_90_253 = 253,Grey_95_254 = 254,Grey_99_255 = 255
}

// Vec3 
public readonly struct Vec3
{
    public readonly float X, Y, Z;
    public Vec3(float x, float y, float z) { X=x; Y=y; Z=z; }

    public static Vec3 operator +(Vec3 a, Vec3 b) => new(a.X+b.X, a.Y+b.Y, a.Z+b.Z);
    public static Vec3 operator -(Vec3 a, Vec3 b) => new(a.X-b.X, a.Y-b.Y, a.Z-b.Z);
    public static Vec3 operator *(Vec3 a, float s) => new(a.X*s, a.Y*s, a.Z*s);
    public static Vec3 operator *(float s, Vec3 a) => a * s;

    public static float Dot(Vec3 a, Vec3 b)  => a.X*b.X + a.Y*b.Y + a.Z*b.Z;
    public static Vec3  Cross(Vec3 u, Vec3 v) => new(
        u.Y*v.Z-u.Z*v.Y, u.Z*v.X-u.X*v.Z, u.X*v.Y-u.Y*v.X);

    public Vec3 Normalised()
    {
        float l = MathF.Sqrt(X*X+Y*Y+Z*Z);
        if (l < 1e-7f) l = 1f;
        return new(X/l, Y/l, Z/l);
    }
}

//RigidBody

public class RigidBody
{
    public Vec3  LinearVelocity  = new(0,0,0);
    public Vec3  AngularVelocity = new(0,0,0);
    public Vec3  Force           = new(0,0,0);
    public Vec3  Torque          = new(0,0,0);
    public float Mass            = 1f;
    public float Restitution     = 0.4f;
    public float Friction        = 0.5f;
    public bool  IsAwake         = true;
    public float SleepTimer      = 0f;   
    public Vec3  InertiaTensor   = new(1,1,1);

  
    public Vec3  CenterOfMass    = new(0,0,0);

    // Recompute diagonal inertia 
    public void ComputeBoxInertia(Vec3 scale)
    {
        float m  = Mass;
        float hx = MathF.Abs(scale.X);
        float hy = MathF.Abs(scale.Y);
        float hz = MathF.Abs(scale.Z);
        InertiaTensor = new Vec3(
            m / 12f * (hy*hy + hz*hz),
            m / 12f * (hx*hx + hz*hz),
            m / 12f * (hx*hx + hy*hy));
    }

    public void AddForce(Vec3 force)   => Force  = Force  + force;
    public void AddTorque(Vec3 torque) => Torque = Torque + torque;
    public void ClearAccumulators()    { Force = new(0,0,0); Torque = new(0,0,0); }
}

//Mesh
public class Mesh
{
    public readonly Vec3[] Verts;
    public readonly (int i0,int i1,int i2,int i3,float bias)[] Quads;

    public Mesh(Vec3[] verts, (int,int,int,int,float)[] quads)
    { Verts=verts; Quads=quads; }

    public static Mesh Cube() => new(
        new Vec3[]
        {
            new(-1,-1,-1), new(1,-1,-1), new(1,1,-1), new(-1,1,-1),
            new(-1,-1, 1), new(1,-1, 1), new(1,1, 1), new(-1,1, 1),
        },
        new (int,int,int,int,float)[]
        {
            (0,3,2,1,  0f),
            (4,5,6,7,  0f),
            (0,4,7,3,-0.1f),
            (1,2,6,5,-0.1f),
            (3,7,6,2, 0.1f),
            (0,1,5,4,-0.2f),
        });

    public static Mesh Pyramid() => new(
        new Vec3[]
        {
            new(-1,-1,-1), new(1,-1,-1), new(1,-1,1), new(-1,-1,1),
            new(0,1,0),
        },
        new (int,int,int,int,float)[]
        {
            (0,1,2,3,-0.2f),
            (1,0,4,4, 0.0f),
            (2,1,4,4,-0.1f),
            (3,2,4,4, 0.0f),
            (0,3,4,4,-0.1f),
        });

    public static Mesh Plane(float s=1f) => FlatBox(s);



    public static Mesh  kugel() => RandomAhhhMeshshit.GenerateSphereMesh(40,40,5f);

    


    public static Mesh FlatBox(float s=1f) => new(
        new Vec3[]
        {
            new(-s,-0.1f,-s), new(s,-0.1f,-s), new(s,-0.1f,s), new(-s,-0.1f,s),
            new(-s, 0.1f,-s), new(s, 0.1f,-s), new(s, 0.1f,s), new(-s, 0.1f,s),
        },
        new (int,int,int,int,float)[]
        {
            (3,7,6,2,-0.1f),
            (0,1,5,4,-0.1f),
            (1,2,6,5,-0.1f),
            (0,4,7,3,-0.1f),
            (4,5,6,7,-0.1f),
            (3,2,1,0,-0.2f),
        });

    public static Mesh _TesseractPlaceholder() => new(
        new Vec3[]{ new(0,0,0) },
        new (int,int,int,int,float)[]{ (0,0,0,0,0f) });

    public static Mesh Tesseract() => new(
        new Vec3[]
        {
            new( 1f, 1f, 1f), new( 1f, 1f,-1f), new( 1f,-1f, 1f), new( 1f,-1f,-1f),
            new(-1f, 1f, 1f), new(-1f, 1f,-1f), new(-1f,-1f, 1f), new(-1f,-1f,-1f),
            new( 0.5f, 0.5f, 0.5f), new( 0.5f, 0.5f,-0.5f),
            new( 0.5f,-0.5f, 0.5f), new( 0.5f,-0.5f,-0.5f),
            new(-0.5f, 0.5f, 0.5f), new(-0.5f, 0.5f,-0.5f),
            new(-0.5f,-0.5f, 0.5f), new(-0.5f,-0.5f,-0.5f),
        },
        new (int,int,int,int,float)[]
        {
            (0,1,3,2, 0.00f), (4,6,7,5, 0.00f),
            (0,4,5,1, 0.05f), (2,3,7,6, 0.05f),
            (0,2,6,4,-0.05f), (1,5,7,3,-0.05f),
            (8,10,11,9,  0.00f), (12,13,15,14, 0.00f),
            (8,9,13,12,  0.05f), (10,14,15,11, 0.05f),
            (8,12,14,10,-0.05f), (9,11,15,13, -0.05f),
            (0,8,9,1,   -0.10f), (2,3,11,10, -0.10f),
            (0,2,10,8,  -0.10f), (1,9,11,3,  -0.10f),
            (4,5,13,12, -0.10f), (6,14,15,7, -0.10f),
            (4,12,14,6, -0.10f), (5,7,15,13, -0.10f),
            (0,4,12,8,  -0.10f), (1,9,13,5,  -0.10f),
            (2,10,14,6, -0.10f), (3,7,15,11, -0.10f),
        });
}

//Tesseract4D
public class Tesseract4D
{
    static readonly (float x,float y,float z,float w)[] Verts4 =
    {
        ( 1, 1, 1, 1), ( 1, 1,-1, 1), ( 1,-1, 1, 1), ( 1,-1,-1, 1),
        (-1, 1, 1, 1), (-1, 1,-1, 1), (-1,-1, 1, 1), (-1,-1,-1, 1),
        ( 1, 1, 1,-1), ( 1, 1,-1,-1), ( 1,-1, 1,-1), ( 1,-1,-1,-1),
        (-1, 1, 1,-1), (-1, 1,-1,-1), (-1,-1, 1,-1), (-1,-1,-1,-1),
    };

    static readonly (int i0,int i1,int i2,int i3,float bias)[] Quads =
    {
        (0,1,3,2, 0.00f), (4,6,7,5, 0.00f),
        (0,4,5,1, 0.05f), (2,3,7,6, 0.05f),
        (0,2,6,4,-0.05f), (1,5,7,3,-0.05f),
        (8,10,11,9,  0.00f), (12,13,15,14, 0.00f),
        (8,9,13,12,  0.05f), (10,14,15,11, 0.05f),
        (8,12,14,10,-0.05f), (9,11,15,13, -0.05f),
        (0,8,9,1,   -0.10f), (2,3,11,10, -0.10f),
        (0,2,10,8,  -0.10f), (1,9,11,3,  -0.10f),
        (4,5,13,12, -0.10f), (6,14,15,7, -0.10f),
        (4,12,14,6, -0.10f), (5,7,15,13, -0.10f),
        (0,4,12,8,  -0.10f), (1,9,13,5,  -0.10f),
        (2,10,14,6, -0.10f), (3,7,15,11, -0.10f),
    };

    public float AngleXW=0f, AngleYW=0f, AngleZW=0f;
    public float AngleXY=0f, AngleXZ=0f, AngleYZ=0f;
    public float WDist=2f;

    public Mesh Project4D()
    {
        var verts3 = new Vec3[16];
        for (int i = 0; i < 16; i++)
        {
            float x=Verts4[i].x, y=Verts4[i].y, z=Verts4[i].z, w=Verts4[i].w;
            if (AngleXW!=0f){ float c=MathF.Cos(AngleXW),s=MathF.Sin(AngleXW); float nx=x*c-w*s,nw=x*s+w*c; x=nx; w=nw; }
            if (AngleYW!=0f){ float c=MathF.Cos(AngleYW),s=MathF.Sin(AngleYW); float ny=y*c-w*s,nw=y*s+w*c; y=ny; w=nw; }
            if (AngleZW!=0f){ float c=MathF.Cos(AngleZW),s=MathF.Sin(AngleZW); float nz=z*c-w*s,nw=z*s+w*c; z=nz; w=nw; }
            if (AngleXY!=0f){ float c=MathF.Cos(AngleXY),s=MathF.Sin(AngleXY); float nx=x*c-y*s,ny=x*s+y*c; x=nx; y=ny; }
            if (AngleXZ!=0f){ float c=MathF.Cos(AngleXZ),s=MathF.Sin(AngleXZ); float nx=x*c-z*s,nz=x*s+z*c; x=nx; z=nz; }
            if (AngleYZ!=0f){ float c=MathF.Cos(AngleYZ),s=MathF.Sin(AngleYZ); float ny=y*c-z*s,nz=y*s+z*c; y=ny; z=nz; }
            float wp = WDist - w;
            if (MathF.Abs(wp) < 0.001f) wp = 0.001f;
            float sc = 1f / wp;
            verts3[i] = new Vec3(x*sc, y*sc, z*sc);
        }
        return new Mesh(verts3, Quads);
    }
}

//SceneObject
public class SceneObject
{
    public Vec3        Position;
    public Vec3        Scale;
    public float       RotX, RotY, RotZ;
    public Mesh        Mesh;
    public Color       Color;
    public Tesseract4D? Tess4D;
    public RigidBody?  Body;      

    public float SpinXW=0f, SpinYW=0f, SpinZW=0f;

    public static float Deg(float degrees) => degrees * MathF.PI / 180f;

    public SceneObject(Mesh mesh,
                       float x=0,           float y=0,           float z=0,
                       float scaleX=1,      float scaleY=1,      float scaleZ=1,
                       float rotX=0,        float rotY=0,        float rotZ=0,
                       Color color=Color.White,
                       bool  rigidBody=false,
                       float mass=1f,
                       float restitution=0.4f,
                       float friction=0.5f,
                       float comX=0f,       float comY=0f,       float comZ=0f)
    {
        Mesh=mesh; Color=color;
        Position=new Vec3(x,y,z);
        Scale   =new Vec3(scaleX,scaleY,scaleZ);
        RotX=rotX; RotY=rotY; RotZ=rotZ;

        if (rigidBody)
        {
            Body = new RigidBody
            {
                Mass          = mass,
                Restitution   = restitution,
                Friction      = friction,
                CenterOfMass  = new Vec3(comX, comY, comZ),
            };
            Body.ComputeBoxInertia(Scale);
        }
    }

    public static SceneObject Tesseract(
        float x=0, float y=0, float z=0,
        float scaleX=1, float scaleY=1, float scaleZ=1,
        float rotX=0,   float rotY=0,   float rotZ=0,
        Color color=Color.White, float wDist=2f,
        float spinXW=0.7f, float spinYW=0.4f, float spinZW=0f)
    {
        var tess = new Tesseract4D { WDist=wDist };
        var obj  = new SceneObject(tess.Project4D(), x,y,z, scaleX,scaleY,scaleZ,
                                   rotX,rotY,rotZ, color)
        { Tess4D=tess, SpinXW=spinXW, SpinYW=spinYW, SpinZW=spinZW };
        return obj;
    }

    public Vec3 LocalToWorld(Vec3 v)
    {
        v = new Vec3(v.X*Scale.X, v.Y*Scale.Y, v.Z*Scale.Z);
        if (RotX!=0f){ float c=MathF.Cos(RotX),s=MathF.Sin(RotX); v=new(v.X, c*v.Y-s*v.Z, s*v.Y+c*v.Z); }
        if (RotY!=0f){ float c=MathF.Cos(RotY),s=MathF.Sin(RotY); v=new(c*v.X+s*v.Z, v.Y, -s*v.X+c*v.Z); }
        if (RotZ!=0f){ float c=MathF.Cos(RotZ),s=MathF.Sin(RotZ); v=new(c*v.X-s*v.Y, s*v.X+c*v.Y, v.Z); }
        return v+Position;
    }

    public Vec3 WorldToLocal(Vec3 w)
    {
        Vec3 v = w - Position;
        if (RotZ!=0f){ float c=MathF.Cos(-RotZ),s=MathF.Sin(-RotZ); v=new(c*v.X-s*v.Y, s*v.X+c*v.Y, v.Z); }
        if (RotY!=0f){ float c=MathF.Cos(-RotY),s=MathF.Sin(-RotY); v=new(c*v.X+s*v.Z, v.Y, -s*v.X+c*v.Z); }
        if (RotX!=0f){ float c=MathF.Cos(-RotX),s=MathF.Sin(-RotX); v=new(v.X, c*v.Y-s*v.Z, s*v.Y+c*v.Z); }
        float sx=MathF.Abs(Scale.X)>1e-7f?Scale.X:1f;
        float sy=MathF.Abs(Scale.Y)>1e-7f?Scale.Y:1f;
        float sz=MathF.Abs(Scale.Z)>1e-7f?Scale.Z:1f;
        return new Vec3(v.X/sx, v.Y/sy, v.Z/sz);
    }

    public void GetLocalAABB(out Vec3 lmin, out Vec3 lmax)
    {
        float minX=float.MaxValue, minY=float.MaxValue, minZ=float.MaxValue;
        float maxX=float.MinValue, maxY=float.MinValue, maxZ=float.MinValue;
        foreach (var v in Mesh.Verts)
        {
            if (v.X<minX) minX=v.X; if (v.X>maxX) maxX=v.X;
            if (v.Y<minY) minY=v.Y; if (v.Y>maxY) maxY=v.Y;
            if (v.Z<minZ) minZ=v.Z; if (v.Z>maxZ) maxZ=v.Z;
        }
        lmin=new Vec3(minX,minY,minZ);
        lmax=new Vec3(maxX,maxY,maxZ);
    }
}

//Engine
class Engine3D
{
    const int W = 755;
    const int H = 145;

    static readonly char[] Blocks = { ' ', '\u2591', '\u2592', '\u2593', '\u2588' };

    static readonly string[][] ColourRamps = {
    new[]{ "\x1b[38;5;0m", "\x1b[38;5;0m", "\x1b[38;5;0m", "\x1b[38;5;234m" }, // Black
    new[]{ "\x1b[38;5;52m", "\x1b[38;5;52m", "\x1b[38;5;1m", "\x1b[38;5;88m" }, // Maroon
    new[]{ "\x1b[38;5;22m", "\x1b[38;5;22m", "\x1b[38;5;2m", "\x1b[38;5;28m" }, // DarkGreen
    new[]{ "\x1b[38;5;201m", "\x1b[38;5;96m", "\x1b[38;5;3m", "\x1b[38;5;100m" }, // Olive
    new[]{ "\x1b[38;5;17m", "\x1b[38;5;17m", "\x1b[38;5;4m", "\x1b[38;5;18m" }, // Navy
    new[]{ "\x1b[38;5;53m", "\x1b[38;5;53m", "\x1b[38;5;5m", "\x1b[38;5;90m" }, // Purple
    new[]{ "\x1b[38;5;23m", "\x1b[38;5;23m", "\x1b[38;5;6m", "\x1b[38;5;30m" }, // Teal
    new[]{ "\x1b[38;5;239m", "\x1b[38;5;8m", "\x1b[38;5;7m", "\x1b[38;5;15m" }, // Silver
    new[]{ "\x1b[38;5;237m", "\x1b[38;5;239m", "\x1b[38;5;8m", "\x1b[38;5;251m" }, // Grey
    new[]{ "\x1b[38;5;124m", "\x1b[38;5;160m", "\x1b[38;5;9m", "\x1b[38;5;196m" }, // Red
    new[]{ "\x1b[38;5;71m", "\x1b[38;5;106m", "\x1b[38;5;10m", "\x1b[38;5;46m" }, // Lime
    new[]{ "\x1b[38;5;219m", "\x1b[38;5;187m", "\x1b[38;5;11m", "\x1b[38;5;226m" }, // Yellow
    new[]{ "\x1b[38;5;19m", "\x1b[38;5;20m", "\x1b[38;5;12m", "\x1b[38;5;21m" }, // Blue
    new[]{ "\x1b[38;5;58m", "\x1b[38;5;164m", "\x1b[38;5;13m", "\x1b[38;5;201m" }, // Fuchsia
    new[]{ "\x1b[38;5;73m", "\x1b[38;5;109m", "\x1b[38;5;14m", "\x1b[38;5;51m" }, // Aqua
    new[]{ "\x1b[38;5;242m", "\x1b[38;5;248m", "\x1b[38;5;15m", "\x1b[38;5;15m" }, // White
    new[]{ "\x1b[38;5;0m", "\x1b[38;5;0m", "\x1b[38;5;16m", "\x1b[38;5;234m" }, // Black_00_16
    new[]{ "\x1b[38;5;17m", "\x1b[38;5;17m", "\x1b[38;5;17m", "\x1b[38;5;4m" }, // Blue_07_17
    new[]{ "\x1b[38;5;17m", "\x1b[38;5;4m", "\x1b[38;5;18m", "\x1b[38;5;19m" }, // Blue_13_18
    new[]{ "\x1b[38;5;4m", "\x1b[38;5;18m", "\x1b[38;5;19m", "\x1b[38;5;20m" }, // Blue_20_19
    new[]{ "\x1b[38;5;18m", "\x1b[38;5;19m", "\x1b[38;5;20m", "\x1b[38;5;12m" }, // Blue_26_20
    new[]{ "\x1b[38;5;20m", "\x1b[38;5;12m", "\x1b[38;5;21m", "\x1b[38;5;54m" }, // Blue_33_21
    new[]{ "\x1b[38;5;22m", "\x1b[38;5;22m", "\x1b[38;5;22m", "\x1b[38;5;2m" }, // Green_07_22
    new[]{ "\x1b[38;5;23m", "\x1b[38;5;23m", "\x1b[38;5;23m", "\x1b[38;5;6m" }, // Cyan_13_23
    new[]{ "\x1b[38;5;24m", "\x1b[38;5;24m", "\x1b[38;5;24m", "\x1b[38;5;25m" }, // Azure_20_24
    new[]{ "\x1b[38;5;24m", "\x1b[38;5;24m", "\x1b[38;5;25m", "\x1b[38;5;26m" }, // Azure_26_25
    new[]{ "\x1b[38;5;24m", "\x1b[38;5;25m", "\x1b[38;5;26m", "\x1b[38;5;27m" }, // Azure_33_26
    new[]{ "\x1b[38;5;25m", "\x1b[38;5;26m", "\x1b[38;5;27m", "\x1b[38;5;31m" }, // Azure_40_27
    new[]{ "\x1b[38;5;22m", "\x1b[38;5;2m", "\x1b[38;5;28m", "\x1b[38;5;34m" }, // Green_13_28
    new[]{ "\x1b[38;5;29m", "\x1b[38;5;29m", "\x1b[38;5;29m", "\x1b[38;5;35m" }, // Cyan_20_29
    new[]{ "\x1b[38;5;23m", "\x1b[38;5;6m", "\x1b[38;5;30m", "\x1b[38;5;37m" }, // Cyan_26_30
    new[]{ "\x1b[38;5;26m", "\x1b[38;5;27m", "\x1b[38;5;31m", "\x1b[38;5;32m" }, // Azure_33_31
    new[]{ "\x1b[38;5;27m", "\x1b[38;5;31m", "\x1b[38;5;32m", "\x1b[38;5;33m" }, // Azure_40_32
    new[]{ "\x1b[38;5;31m", "\x1b[38;5;32m", "\x1b[38;5;33m", "\x1b[38;5;38m" }, // Azure_46_33
    new[]{ "\x1b[38;5;2m", "\x1b[38;5;28m", "\x1b[38;5;34m", "\x1b[38;5;64m" }, // Green_20_34
    new[]{ "\x1b[38;5;29m", "\x1b[38;5;29m", "\x1b[38;5;35m", "\x1b[38;5;36m" }, // Cyan_26_35
    new[]{ "\x1b[38;5;29m", "\x1b[38;5;35m", "\x1b[38;5;36m", "\x1b[38;5;41m" }, // Cyan_33_36
    new[]{ "\x1b[38;5;6m", "\x1b[38;5;30m", "\x1b[38;5;37m", "\x1b[38;5;66m" }, // Cyan_40_37
    new[]{ "\x1b[38;5;32m", "\x1b[38;5;33m", "\x1b[38;5;38m", "\x1b[38;5;67m" }, // Azure_46_38
    new[]{ "\x1b[38;5;38m", "\x1b[38;5;67m", "\x1b[38;5;39m", "\x1b[38;5;68m" }, // Azure_53_39
    new[]{ "\x1b[38;5;64m", "\x1b[38;5;65m", "\x1b[38;5;40m", "\x1b[38;5;70m" }, // Green_26_40
    new[]{ "\x1b[38;5;35m", "\x1b[38;5;36m", "\x1b[38;5;41m", "\x1b[38;5;42m" }, // Cyan_33_41
    new[]{ "\x1b[38;5;36m", "\x1b[38;5;41m", "\x1b[38;5;42m", "\x1b[38;5;43m" }, // Cyan_40_42
    new[]{ "\x1b[38;5;41m", "\x1b[38;5;42m", "\x1b[38;5;43m", "\x1b[38;5;72m" }, // Cyan_46_43
    new[]{ "\x1b[38;5;37m", "\x1b[38;5;66m", "\x1b[38;5;44m", "\x1b[38;5;73m" }, // Cyan_53_44
    new[]{ "\x1b[38;5;68m", "\x1b[38;5;69m", "\x1b[38;5;45m", "\x1b[38;5;74m" }, // Azure_59_45
    new[]{ "\x1b[38;5;106m", "\x1b[38;5;10m", "\x1b[38;5;46m", "\x1b[38;5;107m" }, // Green_33_46
    new[]{ "\x1b[38;5;43m", "\x1b[38;5;72m", "\x1b[38;5;47m", "\x1b[38;5;48m" }, // Cyan_40_47
    new[]{ "\x1b[38;5;72m", "\x1b[38;5;47m", "\x1b[38;5;48m", "\x1b[38;5;49m" }, // Cyan_46_48
    new[]{ "\x1b[38;5;47m", "\x1b[38;5;48m", "\x1b[38;5;49m", "\x1b[38;5;78m" }, // Cyan_53_49
    new[]{ "\x1b[38;5;49m", "\x1b[38;5;78m", "\x1b[38;5;50m", "\x1b[38;5;79m" }, // Cyan_59_50
    new[]{ "\x1b[38;5;109m", "\x1b[38;5;14m", "\x1b[38;5;51m", "\x1b[38;5;80m" }, // Cyan_66_51
    new[]{ "\x1b[38;5;52m", "\x1b[38;5;52m", "\x1b[38;5;52m", "\x1b[38;5;1m" }, // Red_07_52
    new[]{ "\x1b[38;5;53m", "\x1b[38;5;53m", "\x1b[38;5;53m", "\x1b[38;5;5m" }, // Magenta_13_53
    new[]{ "\x1b[38;5;12m", "\x1b[38;5;21m", "\x1b[38;5;54m", "\x1b[38;5;55m" }, // Magenta_20_54
    new[]{ "\x1b[38;5;21m", "\x1b[38;5;54m", "\x1b[38;5;55m", "\x1b[38;5;56m" }, // Magenta_26_55
    new[]{ "\x1b[38;5;54m", "\x1b[38;5;55m", "\x1b[38;5;56m", "\x1b[38;5;57m" }, // Magenta_33_56
    new[]{ "\x1b[38;5;55m", "\x1b[38;5;56m", "\x1b[38;5;57m", "\x1b[38;5;91m" }, // Magenta_40_57
    new[]{ "\x1b[38;5;90m", "\x1b[38;5;127m", "\x1b[38;5;58m", "\x1b[38;5;164m" }, // Yellow_13_58
    new[]{ "\x1b[38;5;235m", "\x1b[38;5;237m", "\x1b[38;5;59m", "\x1b[38;5;247m" }, // Grey_20_59
    new[]{ "\x1b[38;5;129m", "\x1b[38;5;165m", "\x1b[38;5;60m", "\x1b[38;5;61m" }, // Cyan_26_60
    new[]{ "\x1b[38;5;165m", "\x1b[38;5;60m", "\x1b[38;5;61m", "\x1b[38;5;62m" }, // Cyan_33_61
    new[]{ "\x1b[38;5;60m", "\x1b[38;5;61m", "\x1b[38;5;62m", "\x1b[38;5;63m" }, // Cyan_40_62
    new[]{ "\x1b[38;5;61m", "\x1b[38;5;62m", "\x1b[38;5;63m", "\x1b[38;5;97m" }, // Cyan_46_63
    new[]{ "\x1b[38;5;28m", "\x1b[38;5;34m", "\x1b[38;5;64m", "\x1b[38;5;65m" }, // Yellow_20_64
    new[]{ "\x1b[38;5;34m", "\x1b[38;5;64m", "\x1b[38;5;65m", "\x1b[38;5;40m" }, // Teal_26_65
    new[]{ "\x1b[38;5;30m", "\x1b[38;5;37m", "\x1b[38;5;66m", "\x1b[38;5;44m" }, // Teal_33_66
    new[]{ "\x1b[38;5;33m", "\x1b[38;5;38m", "\x1b[38;5;67m", "\x1b[38;5;39m" }, // Cyan_40_67
    new[]{ "\x1b[38;5;67m", "\x1b[38;5;39m", "\x1b[38;5;68m", "\x1b[38;5;69m" }, // Cyan_46_68
    new[]{ "\x1b[38;5;39m", "\x1b[38;5;68m", "\x1b[38;5;69m", "\x1b[38;5;45m" }, // Cyan_53_69
    new[]{ "\x1b[38;5;65m", "\x1b[38;5;40m", "\x1b[38;5;70m", "\x1b[38;5;71m" }, // Yellow_26_70
    new[]{ "\x1b[38;5;40m", "\x1b[38;5;70m", "\x1b[38;5;71m", "\x1b[38;5;106m" }, // Teal_33_71
    new[]{ "\x1b[38;5;42m", "\x1b[38;5;43m", "\x1b[38;5;72m", "\x1b[38;5;47m" }, // Teal_40_72
    new[]{ "\x1b[38;5;66m", "\x1b[38;5;44m", "\x1b[38;5;73m", "\x1b[38;5;109m" }, // Teal_46_73
    new[]{ "\x1b[38;5;69m", "\x1b[38;5;45m", "\x1b[38;5;74m", "\x1b[38;5;75m" }, // Cyan_53_74
    new[]{ "\x1b[38;5;45m", "\x1b[38;5;74m", "\x1b[38;5;75m", "\x1b[38;5;110m" }, // Cyan_59_75
    new[]{ "\x1b[38;5;46m", "\x1b[38;5;107m", "\x1b[38;5;76m", "\x1b[38;5;108m" }, // Yellow_33_76
    new[]{ "\x1b[38;5;76m", "\x1b[38;5;108m", "\x1b[38;5;77m", "\x1b[38;5;112m" }, // Teal_40_77
    new[]{ "\x1b[38;5;48m", "\x1b[38;5;49m", "\x1b[38;5;78m", "\x1b[38;5;50m" }, // Teal_46_78
    new[]{ "\x1b[38;5;78m", "\x1b[38;5;50m", "\x1b[38;5;79m", "\x1b[38;5;115m" }, // Teal_53_79
    new[]{ "\x1b[38;5;14m", "\x1b[38;5;51m", "\x1b[38;5;80m", "\x1b[38;5;116m" }, // Teal_59_80
    new[]{ "\x1b[38;5;110m", "\x1b[38;5;111m", "\x1b[38;5;81m", "\x1b[38;5;117m" }, // Cyan_66_81
    new[]{ "\x1b[38;5;112m", "\x1b[38;5;113m", "\x1b[38;5;82m", "\x1b[38;5;148m" }, // Yellow_40_82
    new[]{ "\x1b[38;5;148m", "\x1b[38;5;114m", "\x1b[38;5;83m", "\x1b[38;5;149m" }, // Teal_46_83
    new[]{ "\x1b[38;5;79m", "\x1b[38;5;115m", "\x1b[38;5;84m", "\x1b[38;5;85m" }, // Teal_53_84
    new[]{ "\x1b[38;5;115m", "\x1b[38;5;84m", "\x1b[38;5;85m", "\x1b[38;5;86m" }, // Teal_59_85
    new[]{ "\x1b[38;5;84m", "\x1b[38;5;85m", "\x1b[38;5;86m", "\x1b[38;5;121m" }, // Teal_66_86
    new[]{ "\x1b[38;5;116m", "\x1b[38;5;152m", "\x1b[38;5;87m", "\x1b[38;5;123m" }, // Teal_73_87
    new[]{ "\x1b[38;5;52m", "\x1b[38;5;1m", "\x1b[38;5;88m", "\x1b[38;5;124m" }, // Red_13_88
    new[]{ "\x1b[38;5;89m", "\x1b[38;5;89m", "\x1b[38;5;89m", "\x1b[38;5;125m" }, // Magenta_20_89
    new[]{ "\x1b[38;5;53m", "\x1b[38;5;5m", "\x1b[38;5;90m", "\x1b[38;5;127m" }, // Magenta_26_90
    new[]{ "\x1b[38;5;56m", "\x1b[38;5;57m", "\x1b[38;5;91m", "\x1b[38;5;92m" }, // Magenta_33_91
    new[]{ "\x1b[38;5;57m", "\x1b[38;5;91m", "\x1b[38;5;92m", "\x1b[38;5;93m" }, // Magenta_40_92
    new[]{ "\x1b[38;5;91m", "\x1b[38;5;92m", "\x1b[38;5;93m", "\x1b[38;5;128m" }, // Magenta_46_93
    new[]{ "\x1b[38;5;9m", "\x1b[38;5;196m", "\x1b[38;5;94m", "\x1b[38;5;95m" }, // Orange_20_94
    new[]{ "\x1b[38;5;196m", "\x1b[38;5;94m", "\x1b[38;5;95m", "\x1b[38;5;130m" }, // Pink_26_95
    new[]{ "\x1b[38;5;13m", "\x1b[38;5;201m", "\x1b[38;5;96m", "\x1b[38;5;3m" }, // Pink_33_96
    new[]{ "\x1b[38;5;62m", "\x1b[38;5;63m", "\x1b[38;5;97m", "\x1b[38;5;98m" }, // Purple_40_97
    new[]{ "\x1b[38;5;63m", "\x1b[38;5;97m", "\x1b[38;5;98m", "\x1b[38;5;99m" }, // Purple_46_98
    new[]{ "\x1b[38;5;97m", "\x1b[38;5;98m", "\x1b[38;5;99m", "\x1b[38;5;134m" }, // Purple_53_99
    new[]{ "\x1b[38;5;96m", "\x1b[38;5;3m", "\x1b[38;5;100m", "\x1b[38;5;133m" }, // Yellow_26_100
    new[]{ "\x1b[38;5;100m", "\x1b[38;5;133m", "\x1b[38;5;101m", "\x1b[38;5;170m" }, // Orange_33_101
    new[]{ "\x1b[38;5;237m", "\x1b[38;5;240m", "\x1b[38;5;102m", "\x1b[38;5;188m" }, // Grey_40_102
    new[]{ "\x1b[38;5;134m", "\x1b[38;5;135m", "\x1b[38;5;103m", "\x1b[38;5;104m" }, // Cyan_46_103
    new[]{ "\x1b[38;5;135m", "\x1b[38;5;103m", "\x1b[38;5;104m", "\x1b[38;5;105m" }, // Cyan_53_104
    new[]{ "\x1b[38;5;103m", "\x1b[38;5;104m", "\x1b[38;5;105m", "\x1b[38;5;171m" }, // Cyan_59_105
    new[]{ "\x1b[38;5;70m", "\x1b[38;5;71m", "\x1b[38;5;106m", "\x1b[38;5;10m" }, // Yellow_33_106
    new[]{ "\x1b[38;5;10m", "\x1b[38;5;46m", "\x1b[38;5;107m", "\x1b[38;5;76m" }, // Lime_40_107
    new[]{ "\x1b[38;5;107m", "\x1b[38;5;76m", "\x1b[38;5;108m", "\x1b[38;5;77m" }, // Teal_46_108
    new[]{ "\x1b[38;5;44m", "\x1b[38;5;73m", "\x1b[38;5;109m", "\x1b[38;5;14m" }, // Teal_53_109
    new[]{ "\x1b[38;5;74m", "\x1b[38;5;75m", "\x1b[38;5;110m", "\x1b[38;5;111m" }, // Cyan_59_110
    new[]{ "\x1b[38;5;75m", "\x1b[38;5;110m", "\x1b[38;5;111m", "\x1b[38;5;81m" }, // Cyan_66_111
    new[]{ "\x1b[38;5;108m", "\x1b[38;5;77m", "\x1b[38;5;112m", "\x1b[38;5;113m" }, // Yellow_40_112
    new[]{ "\x1b[38;5;77m", "\x1b[38;5;112m", "\x1b[38;5;113m", "\x1b[38;5;82m" }, // Lime_46_113
    new[]{ "\x1b[38;5;82m", "\x1b[38;5;148m", "\x1b[38;5;114m", "\x1b[38;5;83m" }, // Teal_53_114
    new[]{ "\x1b[38;5;50m", "\x1b[38;5;79m", "\x1b[38;5;115m", "\x1b[38;5;84m" }, // Teal_59_115
    new[]{ "\x1b[38;5;51m", "\x1b[38;5;80m", "\x1b[38;5;116m", "\x1b[38;5;152m" }, // Teal_66_116
    new[]{ "\x1b[38;5;111m", "\x1b[38;5;81m", "\x1b[38;5;117m", "\x1b[38;5;153m" }, // Cyan_73_117
    new[]{ "\x1b[38;5;83m", "\x1b[38;5;149m", "\x1b[38;5;118m", "\x1b[38;5;150m" }, // Yellow_46_118
    new[]{ "\x1b[38;5;150m", "\x1b[38;5;151m", "\x1b[38;5;119m", "\x1b[38;5;154m" }, // Lime_53_119
    new[]{ "\x1b[38;5;119m", "\x1b[38;5;154m", "\x1b[38;5;120m", "\x1b[38;5;155m" }, // Teal_59_120
    new[]{ "\x1b[38;5;85m", "\x1b[38;5;86m", "\x1b[38;5;121m", "\x1b[38;5;122m" }, // Teal_66_121
    new[]{ "\x1b[38;5;86m", "\x1b[38;5;121m", "\x1b[38;5;122m", "\x1b[38;5;158m" }, // Teal_73_122
    new[]{ "\x1b[38;5;152m", "\x1b[38;5;87m", "\x1b[38;5;123m", "\x1b[38;5;159m" }, // Teal_79_123
    new[]{ "\x1b[38;5;1m", "\x1b[38;5;88m", "\x1b[38;5;124m", "\x1b[38;5;160m" }, // Red_20_124
    new[]{ "\x1b[38;5;89m", "\x1b[38;5;89m", "\x1b[38;5;125m", "\x1b[38;5;126m" }, // Magenta_26_125
    new[]{ "\x1b[38;5;89m", "\x1b[38;5;125m", "\x1b[38;5;126m", "\x1b[38;5;161m" }, // Magenta_33_126
    new[]{ "\x1b[38;5;5m", "\x1b[38;5;90m", "\x1b[38;5;127m", "\x1b[38;5;58m" }, // Magenta_40_127
    new[]{ "\x1b[38;5;92m", "\x1b[38;5;93m", "\x1b[38;5;128m", "\x1b[38;5;129m" }, // Magenta_46_128
    new[]{ "\x1b[38;5;93m", "\x1b[38;5;128m", "\x1b[38;5;129m", "\x1b[38;5;165m" }, // Magenta_53_129
    new[]{ "\x1b[38;5;94m", "\x1b[38;5;95m", "\x1b[38;5;130m", "\x1b[38;5;131m" }, // Orange_26_130
    new[]{ "\x1b[38;5;95m", "\x1b[38;5;130m", "\x1b[38;5;131m", "\x1b[38;5;166m" }, // Pink_33_131
    new[]{ "\x1b[38;5;199m", "\x1b[38;5;200m", "\x1b[38;5;132m", "\x1b[38;5;168m" }, // Pink_40_132
    new[]{ "\x1b[38;5;3m", "\x1b[38;5;100m", "\x1b[38;5;133m", "\x1b[38;5;101m" }, // Pink_46_133
    new[]{ "\x1b[38;5;98m", "\x1b[38;5;99m", "\x1b[38;5;134m", "\x1b[38;5;135m" }, // Purple_53_134
    new[]{ "\x1b[38;5;99m", "\x1b[38;5;134m", "\x1b[38;5;135m", "\x1b[38;5;103m" }, // Purple_59_135
    new[]{ "\x1b[38;5;166m", "\x1b[38;5;167m", "\x1b[38;5;136m", "\x1b[38;5;202m" }, // Orange_33_136
    new[]{ "\x1b[38;5;136m", "\x1b[38;5;202m", "\x1b[38;5;137m", "\x1b[38;5;203m" }, // Orange_40_137
    new[]{ "\x1b[38;5;203m", "\x1b[38;5;172m", "\x1b[38;5;138m", "\x1b[38;5;173m" }, // Pink_46_138
    new[]{ "\x1b[38;5;101m", "\x1b[38;5;170m", "\x1b[38;5;139m", "\x1b[38;5;142m" }, // Pink_53_139
    new[]{ "\x1b[38;5;105m", "\x1b[38;5;171m", "\x1b[38;5;140m", "\x1b[38;5;141m" }, // Purple_59_140
    new[]{ "\x1b[38;5;171m", "\x1b[38;5;140m", "\x1b[38;5;141m", "\x1b[38;5;177m" }, // Purple_66_141
    new[]{ "\x1b[38;5;170m", "\x1b[38;5;139m", "\x1b[38;5;142m", "\x1b[38;5;207m" }, // Yellow_40_142
    new[]{ "\x1b[38;5;142m", "\x1b[38;5;207m", "\x1b[38;5;143m", "\x1b[38;5;176m" }, // Orange_46_143
    new[]{ "\x1b[38;5;143m", "\x1b[38;5;176m", "\x1b[38;5;144m", "\x1b[38;5;213m" }, // Orange_53_144
    new[]{ "\x1b[38;5;239m", "\x1b[38;5;243m", "\x1b[38;5;145m", "\x1b[38;5;15m" }, // Grey_59_145
    new[]{ "\x1b[38;5;141m", "\x1b[38;5;177m", "\x1b[38;5;146m", "\x1b[38;5;147m" }, // Cyan_66_146
    new[]{ "\x1b[38;5;177m", "\x1b[38;5;146m", "\x1b[38;5;147m", "\x1b[38;5;183m" }, // Cyan_73_147
    new[]{ "\x1b[38;5;113m", "\x1b[38;5;82m", "\x1b[38;5;148m", "\x1b[38;5;114m" }, // Yellow_46_148
    new[]{ "\x1b[38;5;114m", "\x1b[38;5;83m", "\x1b[38;5;149m", "\x1b[38;5;118m" }, // Lime_53_149
    new[]{ "\x1b[38;5;149m", "\x1b[38;5;118m", "\x1b[38;5;150m", "\x1b[38;5;151m" }, // Lime_59_150
    new[]{ "\x1b[38;5;118m", "\x1b[38;5;150m", "\x1b[38;5;151m", "\x1b[38;5;119m" }, // Teal_66_151
    new[]{ "\x1b[38;5;80m", "\x1b[38;5;116m", "\x1b[38;5;152m", "\x1b[38;5;87m" }, // Teal_73_152
    new[]{ "\x1b[38;5;81m", "\x1b[38;5;117m", "\x1b[38;5;153m", "\x1b[38;5;153m" }, // Cyan_79_153
    new[]{ "\x1b[38;5;151m", "\x1b[38;5;119m", "\x1b[38;5;154m", "\x1b[38;5;120m" }, // Yellow_53_154
    new[]{ "\x1b[38;5;154m", "\x1b[38;5;120m", "\x1b[38;5;155m", "\x1b[38;5;190m" }, // Lime_59_155
    new[]{ "\x1b[38;5;155m", "\x1b[38;5;190m", "\x1b[38;5;156m", "\x1b[38;5;157m" }, // Lime_66_156
    new[]{ "\x1b[38;5;190m", "\x1b[38;5;156m", "\x1b[38;5;157m", "\x1b[38;5;191m" }, // Teal_73_157
    new[]{ "\x1b[38;5;121m", "\x1b[38;5;122m", "\x1b[38;5;158m", "\x1b[38;5;158m" }, // Teal_79_158
    new[]{ "\x1b[38;5;87m", "\x1b[38;5;123m", "\x1b[38;5;159m", "\x1b[38;5;195m" }, // Teal_86_159
    new[]{ "\x1b[38;5;88m", "\x1b[38;5;124m", "\x1b[38;5;160m", "\x1b[38;5;9m" }, // Red_26_160
    new[]{ "\x1b[38;5;125m", "\x1b[38;5;126m", "\x1b[38;5;161m", "\x1b[38;5;162m" }, // Magenta_33_161
    new[]{ "\x1b[38;5;126m", "\x1b[38;5;161m", "\x1b[38;5;162m", "\x1b[38;5;163m" }, // Magenta_40_162
    new[]{ "\x1b[38;5;161m", "\x1b[38;5;162m", "\x1b[38;5;163m", "\x1b[38;5;197m" }, // Magenta_46_163
    new[]{ "\x1b[38;5;127m", "\x1b[38;5;58m", "\x1b[38;5;164m", "\x1b[38;5;13m" }, // Magenta_53_164
    new[]{ "\x1b[38;5;128m", "\x1b[38;5;129m", "\x1b[38;5;165m", "\x1b[38;5;60m" }, // Magenta_59_165
    new[]{ "\x1b[38;5;130m", "\x1b[38;5;131m", "\x1b[38;5;166m", "\x1b[38;5;167m" }, // Orange_33_166
    new[]{ "\x1b[38;5;131m", "\x1b[38;5;166m", "\x1b[38;5;167m", "\x1b[38;5;136m" }, // Pink_40_167
    new[]{ "\x1b[38;5;200m", "\x1b[38;5;132m", "\x1b[38;5;168m", "\x1b[38;5;169m" }, // Pink_46_168
    new[]{ "\x1b[38;5;132m", "\x1b[38;5;168m", "\x1b[38;5;169m", "\x1b[38;5;204m" }, // Pink_53_169
    new[]{ "\x1b[38;5;133m", "\x1b[38;5;101m", "\x1b[38;5;170m", "\x1b[38;5;139m" }, // Pink_59_170
    new[]{ "\x1b[38;5;104m", "\x1b[38;5;105m", "\x1b[38;5;171m", "\x1b[38;5;140m" }, // Purple_66_171
    new[]{ "\x1b[38;5;137m", "\x1b[38;5;203m", "\x1b[38;5;172m", "\x1b[38;5;138m" }, // Orange_40_172
    new[]{ "\x1b[38;5;172m", "\x1b[38;5;138m", "\x1b[38;5;173m", "\x1b[38;5;208m" }, // Orange_46_173
    new[]{ "\x1b[38;5;173m", "\x1b[38;5;208m", "\x1b[38;5;174m", "\x1b[38;5;209m" }, // Pink_53_174
    new[]{ "\x1b[38;5;205m", "\x1b[38;5;206m", "\x1b[38;5;175m", "\x1b[38;5;211m" }, // Pink_59_175
    new[]{ "\x1b[38;5;207m", "\x1b[38;5;143m", "\x1b[38;5;176m", "\x1b[38;5;144m" }, // Pink_66_176
    new[]{ "\x1b[38;5;140m", "\x1b[38;5;141m", "\x1b[38;5;177m", "\x1b[38;5;146m" }, // Purple_73_177
    new[]{ "\x1b[38;5;174m", "\x1b[38;5;209m", "\x1b[38;5;178m", "\x1b[38;5;210m" }, // Orange_46_178
    new[]{ "\x1b[38;5;178m", "\x1b[38;5;210m", "\x1b[38;5;179m", "\x1b[38;5;214m" }, // Orange_53_179
    new[]{ "\x1b[38;5;179m", "\x1b[38;5;214m", "\x1b[38;5;180m", "\x1b[38;5;181m" }, // Orange_59_180
    new[]{ "\x1b[38;5;214m", "\x1b[38;5;180m", "\x1b[38;5;181m", "\x1b[38;5;215m" }, // Pink_66_181
    new[]{ "\x1b[38;5;213m", "\x1b[38;5;184m", "\x1b[38;5;182m", "\x1b[38;5;185m" }, // Pink_73_182
    new[]{ "\x1b[38;5;146m", "\x1b[38;5;147m", "\x1b[38;5;183m", "\x1b[38;5;189m" }, // Purple_79_183
    new[]{ "\x1b[38;5;144m", "\x1b[38;5;213m", "\x1b[38;5;184m", "\x1b[38;5;182m" }, // Yellow_53_184
    new[]{ "\x1b[38;5;184m", "\x1b[38;5;182m", "\x1b[38;5;185m", "\x1b[38;5;186m" }, // Orange_59_185
    new[]{ "\x1b[38;5;182m", "\x1b[38;5;185m", "\x1b[38;5;186m", "\x1b[38;5;219m" }, // Orange_66_186
    new[]{ "\x1b[38;5;186m", "\x1b[38;5;219m", "\x1b[38;5;187m", "\x1b[38;5;11m" }, // Orange_73_187
    new[]{ "\x1b[38;5;240m", "\x1b[38;5;245m", "\x1b[38;5;188m", "\x1b[38;5;15m" }, // Grey_79_188
    new[]{ "\x1b[38;5;147m", "\x1b[38;5;183m", "\x1b[38;5;189m", "\x1b[38;5;189m" }, // Cyan_86_189
    new[]{ "\x1b[38;5;120m", "\x1b[38;5;155m", "\x1b[38;5;190m", "\x1b[38;5;156m" }, // Yellow_59_190
    new[]{ "\x1b[38;5;156m", "\x1b[38;5;157m", "\x1b[38;5;191m", "\x1b[38;5;192m" }, // Lime_66_191
    new[]{ "\x1b[38;5;157m", "\x1b[38;5;191m", "\x1b[38;5;192m", "\x1b[38;5;193m" }, // Lime_73_192
    new[]{ "\x1b[38;5;191m", "\x1b[38;5;192m", "\x1b[38;5;193m", "\x1b[38;5;194m" }, // Lime_79_193
    new[]{ "\x1b[38;5;192m", "\x1b[38;5;193m", "\x1b[38;5;194m", "\x1b[38;5;194m" }, // Teal_86_194
    new[]{ "\x1b[38;5;123m", "\x1b[38;5;159m", "\x1b[38;5;195m", "\x1b[38;5;195m" }, // Teal_92_195
    new[]{ "\x1b[38;5;160m", "\x1b[38;5;9m", "\x1b[38;5;196m", "\x1b[38;5;94m" }, // Red_33_196
    new[]{ "\x1b[38;5;162m", "\x1b[38;5;163m", "\x1b[38;5;197m", "\x1b[38;5;198m" }, // Magenta_40_197
    new[]{ "\x1b[38;5;163m", "\x1b[38;5;197m", "\x1b[38;5;198m", "\x1b[38;5;199m" }, // Magenta_46_198
    new[]{ "\x1b[38;5;197m", "\x1b[38;5;198m", "\x1b[38;5;199m", "\x1b[38;5;200m" }, // Magenta_53_199
    new[]{ "\x1b[38;5;198m", "\x1b[38;5;199m", "\x1b[38;5;200m", "\x1b[38;5;132m" }, // Magenta_59_200
    new[]{ "\x1b[38;5;164m", "\x1b[38;5;13m", "\x1b[38;5;201m", "\x1b[38;5;96m" }, // Magenta_66_201
    new[]{ "\x1b[38;5;167m", "\x1b[38;5;136m", "\x1b[38;5;202m", "\x1b[38;5;137m" }, // Orange_40_202
    new[]{ "\x1b[38;5;202m", "\x1b[38;5;137m", "\x1b[38;5;203m", "\x1b[38;5;172m" }, // Pink_46_203
    new[]{ "\x1b[38;5;168m", "\x1b[38;5;169m", "\x1b[38;5;204m", "\x1b[38;5;205m" }, // Pink_53_204
    new[]{ "\x1b[38;5;169m", "\x1b[38;5;204m", "\x1b[38;5;205m", "\x1b[38;5;206m" }, // Pink_59_205
    new[]{ "\x1b[38;5;204m", "\x1b[38;5;205m", "\x1b[38;5;206m", "\x1b[38;5;175m" }, // Pink_66_206
    new[]{ "\x1b[38;5;139m", "\x1b[38;5;142m", "\x1b[38;5;207m", "\x1b[38;5;143m" }, // Pink_73_207
    new[]{ "\x1b[38;5;138m", "\x1b[38;5;173m", "\x1b[38;5;208m", "\x1b[38;5;174m" }, // Orange_46_208
    new[]{ "\x1b[38;5;208m", "\x1b[38;5;174m", "\x1b[38;5;209m", "\x1b[38;5;178m" }, // Orange_53_209
    new[]{ "\x1b[38;5;209m", "\x1b[38;5;178m", "\x1b[38;5;210m", "\x1b[38;5;179m" }, // Pink_59_210
    new[]{ "\x1b[38;5;206m", "\x1b[38;5;175m", "\x1b[38;5;211m", "\x1b[38;5;212m" }, // Pink_66_211
    new[]{ "\x1b[38;5;175m", "\x1b[38;5;211m", "\x1b[38;5;212m", "\x1b[38;5;218m" }, // Pink_73_212
    new[]{ "\x1b[38;5;176m", "\x1b[38;5;144m", "\x1b[38;5;213m", "\x1b[38;5;184m" }, // Pink_79_213
    new[]{ "\x1b[38;5;210m", "\x1b[38;5;179m", "\x1b[38;5;214m", "\x1b[38;5;180m" }, // Orange_53_214
    new[]{ "\x1b[38;5;180m", "\x1b[38;5;181m", "\x1b[38;5;215m", "\x1b[38;5;216m" }, // Orange_59_215
    new[]{ "\x1b[38;5;181m", "\x1b[38;5;215m", "\x1b[38;5;216m", "\x1b[38;5;217m" }, // Orange_66_216
    new[]{ "\x1b[38;5;215m", "\x1b[38;5;216m", "\x1b[38;5;217m", "\x1b[38;5;220m" }, // Pink_73_217
    new[]{ "\x1b[38;5;211m", "\x1b[38;5;212m", "\x1b[38;5;218m", "\x1b[38;5;218m" }, // Pink_79_218
    new[]{ "\x1b[38;5;185m", "\x1b[38;5;186m", "\x1b[38;5;219m", "\x1b[38;5;187m" }, // Pink_86_219
    new[]{ "\x1b[38;5;216m", "\x1b[38;5;217m", "\x1b[38;5;220m", "\x1b[38;5;221m" }, // Orange_59_220
    new[]{ "\x1b[38;5;217m", "\x1b[38;5;220m", "\x1b[38;5;221m", "\x1b[38;5;222m" }, // Orange_66_221
    new[]{ "\x1b[38;5;220m", "\x1b[38;5;221m", "\x1b[38;5;222m", "\x1b[38;5;223m" }, // Orange_73_222
    new[]{ "\x1b[38;5;221m", "\x1b[38;5;222m", "\x1b[38;5;223m", "\x1b[38;5;224m" }, // Orange_79_223
    new[]{ "\x1b[38;5;222m", "\x1b[38;5;223m", "\x1b[38;5;224m", "\x1b[38;5;224m" }, // Pink_86_224
    new[]{ "\x1b[38;5;11m", "\x1b[38;5;226m", "\x1b[38;5;225m", "\x1b[38;5;227m" }, // Pink_92_225
    new[]{ "\x1b[38;5;187m", "\x1b[38;5;11m", "\x1b[38;5;226m", "\x1b[38;5;225m" }, // Yellow_66_226
    new[]{ "\x1b[38;5;226m", "\x1b[38;5;225m", "\x1b[38;5;227m", "\x1b[38;5;228m" }, // Orange_73_227
    new[]{ "\x1b[38;5;225m", "\x1b[38;5;227m", "\x1b[38;5;228m", "\x1b[38;5;229m" }, // Orange_79_228
    new[]{ "\x1b[38;5;227m", "\x1b[38;5;228m", "\x1b[38;5;229m", "\x1b[38;5;230m" }, // Orange_86_229
    new[]{ "\x1b[38;5;228m", "\x1b[38;5;229m", "\x1b[38;5;230m", "\x1b[38;5;230m" }, // Orange_92_230
    new[]{ "\x1b[38;5;242m", "\x1b[38;5;248m", "\x1b[38;5;231m", "\x1b[38;5;15m" }, // White_99_231
    new[]{ "\x1b[38;5;0m", "\x1b[38;5;232m", "\x1b[38;5;232m", "\x1b[38;5;235m" }, // Grey_00_232
    new[]{ "\x1b[38;5;232m", "\x1b[38;5;232m", "\x1b[38;5;233m", "\x1b[38;5;237m" }, // Grey_04_233
    new[]{ "\x1b[38;5;232m", "\x1b[38;5;233m", "\x1b[38;5;234m", "\x1b[38;5;238m" }, // Grey_09_234
    new[]{ "\x1b[38;5;233m", "\x1b[38;5;234m", "\x1b[38;5;235m", "\x1b[38;5;239m" }, // Grey_13_235
    new[]{ "\x1b[38;5;233m", "\x1b[38;5;234m", "\x1b[38;5;236m", "\x1b[38;5;59m" }, // Grey_17_236
    new[]{ "\x1b[38;5;234m", "\x1b[38;5;235m", "\x1b[38;5;237m", "\x1b[38;5;242m" }, // Grey_22_237
    new[]{ "\x1b[38;5;234m", "\x1b[38;5;236m", "\x1b[38;5;238m", "\x1b[38;5;243m" }, // Grey_26_238
    new[]{ "\x1b[38;5;234m", "\x1b[38;5;236m", "\x1b[38;5;239m", "\x1b[38;5;102m" }, // Grey_30_239
    new[]{ "\x1b[38;5;235m", "\x1b[38;5;237m", "\x1b[38;5;240m", "\x1b[38;5;246m" }, // Grey_34_240
    new[]{ "\x1b[38;5;235m", "\x1b[38;5;238m", "\x1b[38;5;241m", "\x1b[38;5;247m" }, // Grey_39_241
    new[]{ "\x1b[38;5;236m", "\x1b[38;5;238m", "\x1b[38;5;242m", "\x1b[38;5;145m" }, // Grey_43_242
    new[]{ "\x1b[38;5;236m", "\x1b[38;5;239m", "\x1b[38;5;243m", "\x1b[38;5;250m" }, // Grey_47_243
    new[]{ "\x1b[38;5;237m", "\x1b[38;5;239m", "\x1b[38;5;244m", "\x1b[38;5;251m" }, // Grey_52_244
    new[]{ "\x1b[38;5;237m", "\x1b[38;5;240m", "\x1b[38;5;245m", "\x1b[38;5;188m" }, // Grey_56_245
    new[]{ "\x1b[38;5;237m", "\x1b[38;5;59m", "\x1b[38;5;246m", "\x1b[38;5;254m" }, // Grey_60_246
    new[]{ "\x1b[38;5;238m", "\x1b[38;5;241m", "\x1b[38;5;247m", "\x1b[38;5;255m" }, // Grey_65_247
    new[]{ "\x1b[38;5;238m", "\x1b[38;5;242m", "\x1b[38;5;248m", "\x1b[38;5;15m" }, // Grey_69_248
    new[]{ "\x1b[38;5;239m", "\x1b[38;5;243m", "\x1b[38;5;249m", "\x1b[38;5;15m" }, // Grey_73_249
    new[]{ "\x1b[38;5;239m", "\x1b[38;5;243m", "\x1b[38;5;250m", "\x1b[38;5;15m" }, // Grey_77_250
    new[]{ "\x1b[38;5;239m", "\x1b[38;5;8m", "\x1b[38;5;251m", "\x1b[38;5;15m" }, // Grey_82_251
    new[]{ "\x1b[38;5;240m", "\x1b[38;5;102m", "\x1b[38;5;252m", "\x1b[38;5;15m" }, // Grey_86_252
    new[]{ "\x1b[38;5;59m", "\x1b[38;5;245m", "\x1b[38;5;253m", "\x1b[38;5;15m" }, // Grey_90_253
    new[]{ "\x1b[38;5;59m", "\x1b[38;5;246m", "\x1b[38;5;254m", "\x1b[38;5;15m" }, // Grey_95_254
    new[]{ "\x1b[38;5;241m", "\x1b[38;5;247m", "\x1b[38;5;255m", "\x1b[38;5;15m" }, // Grey_99_255
};

    const string ColReset = "\x1b[0m";

    static readonly int[]   CB = new int  [W * H];
    static readonly float[] ZB = new float[W * H];

    static float camX=0f, camY=0f, camZ=-8f;
    static float yaw=0f, pitch=0f;

    static readonly Vec3 Sun = new Vec3(0.6f, 0.9f, -0.4f).Normalised();

    static readonly Stopwatch SW = Stopwatch.StartNew();
    static double prevT = 0;

    //Input
    static readonly HashSet<ConsoleKey> Keys    = new();
    static readonly HashSet<ConsoleKey> KeysRaw = new();
    static readonly Dictionary<ConsoleKey, long> KeyTimestamps = new();
    const long KEY_HOLD_MS = 80;
    static bool sprint=false, shiftRaw=false;
    static readonly object KeyLock = new();

    static readonly float D = MathF.PI / 180f;

    //Player
    static SceneObject Player = new SceneObject(
        Mesh.Cube(), x:0, y:1, z:-8,
        scaleX:0.4f, scaleY:0.9f, scaleZ:0.4f);

    static Vec3 velocity = new Vec3(0,0,0);

    static List<SceneObject> Scene = new()
    {
        new SceneObject(Mesh.Cube(),    x:  0, y: 0, z: 0, color: Color.White,
                        scaleX:1f, scaleY:1f, scaleZ:3f),
        new SceneObject(Mesh.Cube(),    x:  0, y: 4, z: 0, color: Color.White,
                        scaleX:1f, scaleY:3f, scaleZ:1f),
        new SceneObject(Mesh.Pyramid(), x:  0, y: 9, z: 0, color: Color.Yellow_26_70,
                        scaleX:1f, scaleY:2f, scaleZ:1f, rotY: 45*SceneObject.Deg(1)),
        new SceneObject(Mesh.Pyramid(), x: -4, y: 3, z: 4, color: Color.Cyan_33_61,
                        scaleX:1.5f, scaleY:2f, scaleZ:1.5f, rotX: 20*SceneObject.Deg(1), rotZ: -15*SceneObject.Deg(1)),
        new SceneObject(Mesh.Cube(),    x:  4, y: 0, z: 6, color: Color.Yellow_26_70),
        new SceneObject(Mesh.Pyramid(), x:  8, y: 5, z: 3, color: Color.Red_07_52,
                        scaleX:1f, scaleY:1.5f, scaleZ:1f, rotY: 60*SceneObject.Deg(1)),
        new SceneObject(Mesh.Plane(),   x: -10, y:-1, z:  5, color: Color.Azure_20_24,  scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x: -10, y:-1, z: 15, color: Color.Azure_59_45,    scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x: -10, y:-1, z: 25, color: Color.Blue_07_17,   scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x: -10, y:-1, z: -5, color: Color.Azure_20_24, scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:   0, y:-1, z: -5, color: Color.Grey_17_236,  scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:   0, y:-1, z:  5, color: Color.DarkGreen,    scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:   0, y:-1, z: 15, color: Color.Blue_07_17,   scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:   0, y:-1, z: 25, color: Color.Azure_20_24, scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  10, y:-1, z:  5, color: Color.Grey_17_236,  scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  10, y:-1, z: 15, color: Color.DarkGreen,    scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  10, y:-1, z: 25, color: Color.Blue_07_17,   scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  10, y:-1, z: -5, color: Color.Azure_20_24, scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  20, y:-1, z: -5, color: Color.Grey_17_236,  scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  20, y:-1, z:  5, color: Color.DarkGreen,    scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  20, y:-1, z: 15, color: Color.Blue_07_17,   scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  20, y:-1, z: 25, color: Color.Azure_20_24, scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  30, y:-1, z:  5, color: Color.Grey_17_236,  scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  30, y:-1, z: 15, color: Color.DarkGreen,    scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  30, y:-1, z: 25, color: Color.Blue_07_17,   scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  30, y:-1, z: -5, color: Color.Azure_20_24, scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  40, y:-1, z: -5, color: Color.Grey_17_236,  scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  40, y:-1, z:  5, color: Color.DarkGreen,    scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  40, y:-1, z: 15, color: Color.Blue_07_17,   scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  40, y:-1, z: 25, color: Color.Azure_20_24, scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  50, y:-1, z:  5, color: Color.Grey_17_236,  scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  50, y:-1, z: 15, color: Color.DarkGreen,    scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  50, y:-1, z: 25, color: Color.Blue_07_17,   scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x:  50, y:-1, z: -5, color: Color.Azure_20_24, scaleX:-5f, scaleY:1f, scaleZ:5f),
        new SceneObject(Mesh.Plane(),   x: 20, y: 4f, z: 10, color: Color.DarkGreen,
                        scaleX:-5f, scaleY:1f, scaleZ:5f, rotX:90*SceneObject.Deg(1)),
        new SceneObject(Mesh.Plane(),   x: 25, y: 4f, z: 15, color: Color.Black,
                        scaleX:-5f, scaleY:1f, scaleZ:5f, rotX:90*SceneObject.Deg(1), rotY:90*SceneObject.Deg(1)),
        new SceneObject(Mesh.Plane(),   x: 20, y: 4f, z: 20, color: Color.Blue_07_17,
                        scaleX:-5f, scaleY:1f, scaleZ:5f, rotX:90*SceneObject.Deg(1)),
        new SceneObject(Mesh.Plane(),   x: 20, y: 9,  z: 15, color: Color.Green_33_46,
                        scaleX:-5f, scaleY:1f, scaleZ:5f),

        new SceneObject(Mesh.Cube(), x:-5,  y:9, z:20, scaleX:1, scaleY:10, scaleZ:1, color: Color.Blue_07_17),
        new SceneObject(Mesh.Cube(), x:-15, y:9, z:10, scaleX:1, scaleY:10, scaleZ:1, color: Color.Blue_07_17,
                        rotY:45, rotX:(float)Gametest.rampWinkel(Gametest.c(5,5),10,Gametest.rampL(Gametest.c(5,5),10))),

       
        new SceneObject(Mesh.Cube(), x:5, y:15, z:5, color:Color.Red_33_196,
                        rigidBody:true, mass:1f, restitution:0.5f),

        
        new SceneObject(Mesh.Cube(), x:-3, y:20, z:8, color:Color.Orange_40_137,
                        scaleX:1.5f, scaleY:1.5f, scaleZ:1.5f,
                        rigidBody:true, mass:3f, restitution:0.1f),

        
        SceneObject.Tesseract(x:20, y:20, z:15, scaleX:-3f, scaleY:-3f, scaleZ:-3f,
                              color:Color.Purple_53_99, spinXW:3f, spinYW:3f),

        
        new SceneObject(Mesh.kugel(), x:50 ,y:20 , z:0 , scaleX:1,scaleY:1,scaleZ:1,color: Color.Purple_53_134, rigidBody:true , mass:1f)
    };

    static readonly int StaticSceneCount = Scene.Count;

    //Code generator
    static string MeshName(Mesh m) => m.Verts.Length switch
    {
        8 => "Mesh.Cube()",
        5 => "Mesh.Pyramid()",
        _ => "Mesh.Plane()"
    };

    static void PrintGeneratedObjects()
    {
        int added = Scene.Count - StaticSceneCount;
        if (added <= 0) { Console.WriteLine("// No objects were added during this session."); return; }
        Console.WriteLine($"// ── {added} generated object(s) ──");
        for (int i = StaticSceneCount; i < Scene.Count; i++)
        {
            var o = Scene[i];
            static string F(float v) => v==MathF.Floor(v) ? $"{v:F0}f" : $"{v:F4}f";
            var sb = new System.Text.StringBuilder();
            sb.Append($"        new SceneObject({MeshName(o.Mesh),-14} x:{F(o.Position.X),8}, y:{F(o.Position.Y),8}, z:{F(o.Position.Z),8}, color: Color.{o.Color,-8}");
            sb.Append($", scaleX:{F(o.Scale.X),8}, scaleY:{F(o.Scale.Y),8}, scaleZ:{F(o.Scale.Z),8}");
            if (o.RotX!=0f) sb.Append($", rotX:{F(o.RotX),8}");
            if (o.RotY!=0f) sb.Append($", rotY:{F(o.RotY),8}");
            if (o.RotZ!=0f) sb.Append($", rotZ:{F(o.RotZ),8}");
            if (o.Body!=null)
            {
                sb.Append($", rigidBody:true, mass:{F(o.Body.Mass)}, restitution:{F(o.Body.Restitution)}");
                if (o.Body.CenterOfMass.X!=0f || o.Body.CenterOfMass.Y!=0f || o.Body.CenterOfMass.Z!=0f)
                    sb.Append($", comX:{F(o.Body.CenterOfMass.X)}, comY:{F(o.Body.CenterOfMass.Y)}, comZ:{F(o.Body.CenterOfMass.Z)}");
            }
            sb.Append("),");
            Console.WriteLine(sb);
        }
    }
    
    static float counter;
    static void GameLoop(float dt)
    {
        

        // rigid body simulation runs first every frame pls dont remove
        Physics.StepRigidBodies(Scene, dt);

        counter += 0.02f;
        Scene[1].RotX = counter;
        Scene[3].RotY += 1.0f * dt;

        Scene[43].RotX += 1f *dt;

        Vec3  origin  = new Vec3(camX, camY-0.5f, camZ);
        Vec3  forward = CameraForward();
        Vec3  hitPos  = default;
        float hitDist = 0f;

        if (Keys.Contains(ConsoleKey.G))
        {
            Scene.Add(new SceneObject(Mesh.Cube(), x:50, y:40, z:5,
                                          scaleX:0.5f, scaleY:0.5f, scaleZ:0.5f,
                                          color:Color.Orange_26_130,rigidBody:true,mass:10f));
        }


        var looked = Raycast(forward, 20f);
        if (looked != null)
        {
            Physics.RaycastOne(origin, forward, 20f, looked, out hitDist, out hitPos);
            if (Keys.Contains(ConsoleKey.E))
            {
                int cx=Convert.ToInt32(Math.Round(hitPos.X));
                int cy=Convert.ToInt32(Math.Round(hitPos.Y));
                int cz=Convert.ToInt32(Math.Round(hitPos.Z));
                Scene.Add(new SceneObject(Mesh.Cube(), x:cx, y:cy, z:cz,
                                          scaleX:0.5f, scaleY:0.5f, scaleZ:0.5f,
                                          color:Color.Orange_26_130));
            }
        }

        if (Keys.Contains(ConsoleKey.X) && Scene.Count > 0)
            Scene.RemoveAt(Scene.Count - 1);
    }
 

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible  = false;
        RawInput.Start(Keys, KeyLock, s => { lock(KeyLock){ sprint = s; } });
        try { Console.SetWindowSize(W+4, H+6); } catch { }
        if (OperatingSystem.IsWindows())
            try { Console.SetBufferSize(W+4, H+10); } catch { }
        Console.Clear();

        while (true)
        {
            double now = SW.Elapsed.TotalSeconds;
            float  dt  = (float)Math.Min(now-prevT, 0.05);
            prevT = now;

            PollKeys();
            if (Keys.Contains(ConsoleKey.Q) || Keys.Contains(ConsoleKey.Escape)) break;

            UpdateCamera(dt);
            GameLoop(dt);
            Render(dt);

            int ms = (int)((SW.Elapsed.TotalSeconds-now)*1000);
            if (ms < 16) System.Threading.Thread.Sleep(16-ms);
        }

        Console.Write(ColReset);
        Console.CursorVisible = true;
        Console.Clear();
        PrintGeneratedObjects();
        Console.WriteLine("\nGoodbye. Press any key to exit.");
        Console.ReadKey(true);
    }


// N-key rollover input using /dev/input directly.
// Replaces the Console.ReadKey polling loop entirely.




public static class RawInput
{
    [StructLayout(LayoutKind.Sequential)]
    struct InputEvent
    {
        public long   tv_sec;
        public long   tv_usec;
        public ushort type;
        public ushort code;
        public int    value;
    }
 
    const ushort EV_KEY    = 1;
    const int    KEY_PRESS = 1;
 
    static readonly Dictionary<ushort, ConsoleKey> KeyMap = new()
    {
        [17]  = ConsoleKey.W,
        [31]  = ConsoleKey.S,
        [30]  = ConsoleKey.A,
        [32]  = ConsoleKey.D,
        [57]  = ConsoleKey.Spacebar,
        [46]  = ConsoleKey.C,
        [18]  = ConsoleKey.E,
        [34]  = ConsoleKey.G,
        [45]  = ConsoleKey.X,
        [19]  = ConsoleKey.R,
        [16]  = ConsoleKey.Q,
        [1]   = ConsoleKey.Escape,
        [105] = ConsoleKey.LeftArrow,
        [106] = ConsoleKey.RightArrow,
        [103] = ConsoleKey.UpArrow,
        [108] = ConsoleKey.DownArrow,
    };
 
    static readonly HashSet<ushort> ShiftCodes = new() { 42, 54 };
 
    public static bool Available { get; private set; } = false;
 
    public static void Start(HashSet<ConsoleKey> keys, object keyLock, Action<bool> setSprint)
    {
        string? dev = "/dev/input/event7";
        //string? dev = FindKeyboard();
        if (dev == null)
        {
            //Console.Error.WriteLine("[RawInput] keyboard device not found");
            return;
        }
 
        Available = true;
        var t = new Thread(() =>
        {
            try
            {
                using var fs = new FileStream(dev, FileMode.Open,
                                              FileAccess.Read, FileShare.ReadWrite);
                int    evSize = Marshal.SizeOf<InputEvent>();
                byte[] buf    = new byte[evSize];
                bool   shift  = false;
 
                //Console.Error.WriteLine($"[RawInput] opened {dev}, evSize={evSize}");
 
                while (true)
                {
                    int read = fs.Read(buf, 0, evSize);
                    if (read < evSize) continue;
 
                    var ev = MemoryMarshal.Read<InputEvent>(buf);
 
                    if (ev.type == EV_KEY)
                        //Console.Error.WriteLine($"[RawInput] type={ev.type} code={ev.code} value={ev.value}");
 
                    if (ev.type != EV_KEY) continue;
 
                    bool pressed = ev.value == KEY_PRESS;
 
                    if (ShiftCodes.Contains(ev.code))
                    {
                        shift = pressed;
                        setSprint(shift);
                        continue;
                    }
 
                    if (ev.value == 2) continue;
                    if (!KeyMap.TryGetValue(ev.code, out var ck)) continue;
 
                    lock (keyLock)
                    {
                        if (pressed) keys.Add(ck);
                        else         keys.Remove(ck);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Console.Error.WriteLine(
                    //$"[RawInput] Permission denied on {dev}.\n" +
                    //$"Fix with:  sudo usermod -aG input $USER  then log out and back in.");
                Available = false;
            }
            catch (Exception ex)
            {
                //Console.Error.WriteLine($"[RawInput] Error: {ex.Message}");
                Available = false;
            }
        });
        t.IsBackground = true;
        t.Name = "RawInput";
        t.Start();
    }
 
    static string? FindKeyboard()
    {
        try
        {
            string info = File.ReadAllText("/proc/bus/input/devices");
            string[] blocks = info.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (var block in blocks)
            {
                bool isKeyboard = false;
                string eventDev = "";
                foreach (var line in block.Split('\n'))
                {
                    if (!line.StartsWith("H: Handlers=")) continue;
                    if (line.Contains("kbd")) isKeyboard = true;
                    foreach (var token in line[12..].Split(' '))
                        if (token.StartsWith("event"))
                            eventDev = "/dev/input/" + token.Trim();
                }
                if (isKeyboard && eventDev != "")
                    return eventDev;
            }
        }
        catch { }
 
        for (int i = 0; i < 20; i++)
        {
            string p = $"/dev/input/event{i}";
            if (File.Exists(p)) return p;
        }
        return null;
    }
}



    static void PollKeys()
{
    if (RawInput.Available) return;

    lock (KeyLock)
    {
        Keys.Clear();
        foreach (var k in KeyTimestamps.Keys) Keys.Add(k);
        foreach (var k in KeysRaw) Keys.Add(k);
        sprint   = shiftRaw;
        shiftRaw = false;
        KeysRaw.Clear();
    }
}

    static void UpdateCamera(float dt)
    {
        const float look    = 1.8f;
        const float speed   = 6f;
        const float gravity = -18f;

        if (Keys.Contains(ConsoleKey.LeftArrow))  yaw  -= look*dt;
        if (Keys.Contains(ConsoleKey.RightArrow)) yaw  += look*dt;
        if (Keys.Contains(ConsoleKey.UpArrow))
            pitch = Math.Clamp(pitch-look*dt, -1.45f, 1.45f);
        if (Keys.Contains(ConsoleKey.DownArrow))
            pitch = Math.Clamp(pitch+look*dt, -1.45f, 1.45f);

        float fwdX=MathF.Sin(yaw), fwdZ=MathF.Cos(yaw);
        float rgtX=fwdZ,           rgtZ=-fwdX;
        float spd=sprint?speed*2f:speed;

        float moveX=0f, moveZ=0f;
        if (Keys.Contains(ConsoleKey.W)) { moveX+=fwdX*spd; moveZ+=fwdZ*spd; }
        if (Keys.Contains(ConsoleKey.S)) { moveX-=fwdX*spd; moveZ-=fwdZ*spd; }
        if (Keys.Contains(ConsoleKey.A)) { moveX-=rgtX*spd; moveZ-=rgtZ*spd; }
        if (Keys.Contains(ConsoleKey.D)) { moveX+=rgtX*spd; moveZ+=rgtZ*spd; }

        velocity = new Vec3(moveX, velocity.Y, moveZ);
        velocity = new Vec3(velocity.X, velocity.Y+gravity*dt, velocity.Z);

        if (Keys.Contains(ConsoleKey.Spacebar))
            velocity = new Vec3(velocity.X, 8f, velocity.Z);
        if (Keys.Contains(ConsoleKey.C))
            velocity = new Vec3(velocity.X, -8f, velocity.Z);

        velocity = Physics.MoveAndCollide(Player, velocity, dt, Scene);
        velocity = new Vec3(velocity.X, Math.Max(velocity.Y, -30f), velocity.Z);

        camX = Player.Position.X;
        camY = Player.Position.Y + 0.6f;
        camZ = Player.Position.Z;

        if (Keys.Contains(ConsoleKey.R))
        {
            Player.Position = new Vec3(0, 1, -8);
            velocity = new Vec3(0, 0, 0);
            yaw=0; pitch=0;
        }
    }

    static void Render(float dt)
    {
        Array.Fill(CB, 0);
        Array.Fill(ZB, float.MaxValue);
        foreach (var obj in Scene) DrawObject(obj);
        Flush(dt);
    }

    static void DrawObject(SceneObject obj)
    {
        if (obj.Tess4D != null)
        {
            float dt = (float)(SW.Elapsed.TotalSeconds - prevT);
            obj.Tess4D.AngleXW += obj.SpinXW * dt;
            obj.Tess4D.AngleYW += obj.SpinYW * dt;
            obj.Tess4D.AngleZW += obj.SpinZW * dt;
            obj.Mesh = obj.Tess4D.Project4D();
        }
        var mesh=obj.Mesh;
        var lv=mesh.Verts;
        var vv=new Vec3[lv.Length];
        for (int i=0; i<lv.Length; i++)
            vv[i]=WorldToView(obj.LocalToWorld(lv[i]));

        foreach (var (i0,i1,i2,i3,bias) in mesh.Quads)
        {
            Vec3 e1=vv[i1]-vv[i0], e2=vv[i2]-vv[i0];
            if (Vec3.Dot(Vec3.Cross(e1,e2), vv[i0]) >= 0f) continue;

            Vec3 we1=obj.LocalToWorld(lv[i1])-obj.LocalToWorld(lv[i0]);
            Vec3 we2=obj.LocalToWorld(lv[i2])-obj.LocalToWorld(lv[i0]);
            Vec3 wn=Vec3.Cross(we1,we2).Normalised();

            float diff=Math.Max(0f, Vec3.Dot(wn, Sun));
            float lum=Math.Clamp(0.15f+0.85f*diff+bias, 0f, 1f);
            int shade = Math.Clamp((int)(lum*4f+0.5f), 1, 4);
            int cell  = (((int)obj.Color) << 3) | shade;

            ClipAndDraw(vv[i0], vv[i1], vv[i2], cell);
            ClipAndDraw(vv[i0], vv[i2], vv[i3], cell);
        }
    }

    static void ClipAndDraw(Vec3 a, Vec3 b, Vec3 c, int cell)
    {
        static Vec3 ClipEdge(Vec3 inside, Vec3 outside)
        {
            float t=(NEAR-inside.Z)/(outside.Z-inside.Z);
            return new Vec3(inside.X+t*(outside.X-inside.X),
                            inside.Y+t*(outside.Y-inside.Y), NEAR);
        }
        bool aIn=a.Z>NEAR, bIn=b.Z>NEAR, cIn=c.Z>NEAR;
        int cnt=(aIn?1:0)+(bIn?1:0)+(cIn?1:0);
        if (cnt==0) return;
        if (cnt==3) { RasterTri(Project(a),Project(b),Project(c),cell); return; }
        if (cnt==1)
        {
            Vec3 v0=aIn?a:bIn?b:c, v1=aIn?b:bIn?c:a, v2=aIn?c:bIn?a:b;
            RasterTri(Project(v0),Project(ClipEdge(v0,v1)),Project(ClipEdge(v0,v2)),cell);
            return;
        }
        {
            Vec3 v0=!aIn?a:!bIn?b:c, v1=!aIn?b:!bIn?c:a, v2=!aIn?c:!bIn?a:b;
            Vec3 c1=ClipEdge(v1,v0), c2=ClipEdge(v2,v0);
            RasterTri(Project(v1),Project(c1),Project(v2),cell);
            RasterTri(Project(c1),Project(c2),Project(v2),cell);
        }
    }

    static Vec3 WorldToView(Vec3 w)
    {
        float tx=w.X-camX, ty=w.Y-camY, tz=w.Z-camZ;
        float sinY=MathF.Sin(-yaw), cosY=MathF.Cos(-yaw);
        float rx=cosY*tx+sinY*tz, rz=-sinY*tx+cosY*tz;
        float sinP=MathF.Sin(-pitch), cosP=MathF.Cos(-pitch);
        return new Vec3(rx, cosP*ty-sinP*rz, sinP*ty+cosP*rz);
    }

    const float FOV    = 70f*MathF.PI/180f;
    const float NEAR   = 0.05f;
    const float ASPECT = (float)W/H*0.43f;

    static Vec3 Project(Vec3 v)
    {
        float f=1f/MathF.Tan(FOV*0.5f);
        return new Vec3((v.X/v.Z*f/ASPECT+1f)*0.5f*W,
                        (-v.Y/v.Z*f+1f)*0.5f*H, v.Z);
    }

    static void RasterTri(Vec3 a, Vec3 b, Vec3 c, int cell)
    {
        int x0=Math.Max(0,  (int)MathF.Floor  (Math.Min(a.X,Math.Min(b.X,c.X))));
        int x1=Math.Min(W-1,(int)MathF.Ceiling(Math.Max(a.X,Math.Max(b.X,c.X))));
        int y0=Math.Max(0,  (int)MathF.Floor  (Math.Min(a.Y,Math.Min(b.Y,c.Y))));
        int y1=Math.Min(H-1,(int)MathF.Ceiling(Math.Max(a.Y,Math.Max(b.Y,c.Y))));
        float denom=(b.Y-c.Y)*(a.X-c.X)+(c.X-b.X)*(a.Y-c.Y);
        if (MathF.Abs(denom)<1e-5f) return;
        for (int py=y0; py<=y1; py++)
        for (int px=x0; px<=x1; px++)
        {
            float qx=px+.5f, qy=py+.5f;
            float w0=((b.Y-c.Y)*(qx-c.X)+(c.X-b.X)*(qy-c.Y))/denom;
            float w1=((c.Y-a.Y)*(qx-c.X)+(a.X-c.X)*(qy-c.Y))/denom;
            float w2=1f-w0-w1;
            if (w0<0||w1<0||w2<0) continue;
            float z=w0*a.Z+w1*b.Z+w2*c.Z;
            int idx=py*W+px;
            if (z<ZB[idx]) { ZB[idx]=z; CB[idx]=cell; }
        }
    }

    static void Flush(float dt)
    {
        var sb=new StringBuilder((W+5)*(H+5)*16);
        sb.Append($"  pos({camX:F1},{camY:F1},{camZ:F1})  yaw:{yaw*57.3f:F0}  pitch:{pitch*57.3f:F0}  fps:{(dt>0?1/dt:0):F0}   \n");
        sb.Append("  wasd=move  arrows=look  space/c=fly  shift=sprint  r=reset  q=quit   \n");
        sb.Append("  +"); sb.Append(new string('-',W)); sb.Append("+\n");
        string lastEsc="";
        for (int row=0; row<H; row++)
        {
            sb.Append("  |");
            for (int col=0; col<W; col++)
            {
                int cell=CB[row*W+col];
                if (cell==0)
                {
                    if (lastEsc!="") { sb.Append(ColReset); lastEsc=""; }
                    sb.Append(' ');
                }
                else
                {
                    int colorId=cell>>3;
                    int shade=Math.Clamp(cell&0x7,1,4);
                    string esc=ColourRamps[colorId][shade-1];
                    if (esc!=lastEsc) { sb.Append(esc); lastEsc=esc; }
                    sb.Append(Blocks[shade]);
                }
            }
            if (lastEsc!="") { sb.Append(ColReset); lastEsc=""; }
            sb.Append("|\n");
        }
        sb.Append("  +"); sb.Append(new string('-',W)); sb.Append("+");
        Console.SetCursorPosition(0,0);
        Console.Write(sb);
    }

    static Vec3 CameraForward()
    {
        float cp=MathF.Cos(pitch);
        return new Vec3(MathF.Sin(yaw)*cp, MathF.Sin(pitch), MathF.Cos(yaw)*cp).Normalised();
    }

    static SceneObject? Raycast(Vec3 direction, float maxLength)
        => Physics.Raycast(new Vec3(camX, camY, camZ), direction, maxLength, Scene);
}


public static class Physics
{
    const float Gravity = -18f;
 
    public static void StepRigidBodies(List<SceneObject> scene, float dt)
    {
        const int SubSteps = 3;
        float sdt = dt / SubSteps;
 
        for (int step = 0; step < SubSteps; step++)
        {
            foreach (var obj in scene)
            {
                var b = obj.Body;
                if (b == null || !b.IsAwake) continue;
 
                Vec3 gravForce  = new Vec3(0, Gravity * b.Mass, 0);
                b.AddForce(gravForce);
 
                Vec3 comOffset  = RotateByObject(obj, b.CenterOfMass);
                Vec3 gravTorque = Vec3.Cross(comOffset, gravForce);
                b.AddTorque(gravTorque);
 
                Vec3 accel       = b.Force * (1f / b.Mass);
                b.LinearVelocity = b.LinearVelocity + accel * sdt;
                obj.Position     = obj.Position + b.LinearVelocity * sdt;
 
                Vec3 angAccel     = new Vec3(
                    b.Torque.X / b.InertiaTensor.X,
                    b.Torque.Y / b.InertiaTensor.Y,
                    b.Torque.Z / b.InertiaTensor.Z);
                b.AngularVelocity = b.AngularVelocity + angAccel * sdt;
                obj.RotX         += b.AngularVelocity.X * sdt;
                obj.RotY         += b.AngularVelocity.Y * sdt;
                obj.RotZ         += b.AngularVelocity.Z * sdt;
 
                float angDamp     = MathF.Pow(0.97f, sdt * 60f);
                b.AngularVelocity = b.AngularVelocity * angDamp;
 
                b.ClearAccumulators();
            }
 
            const int SolverIterations = 3;
            for (int iter = 0; iter < SolverIterations; iter++)
            {
                for (int i = 0; i < scene.Count; i++)
                {
                    var a = scene[i];
                    if (a.Body == null || !a.Body.IsAwake) continue;
 
                    for (int k = 0; k < scene.Count; k++)
                    {
                        if (i == k) continue;
                        var other = scene[k];
 
                        GetAABB(a,     out Vec3 amin, out Vec3 amax);
                        GetAABB(other, out Vec3 bmin, out Vec3 bmax);
                        if (!AABBPenetration(amin, amax, bmin, bmax, out Vec3 normal, out float depth))
                            continue;
 
                        if (other.Body != null && !other.Body.IsAwake)
                        {
                            other.Body.IsAwake    = true;
                            other.Body.SleepTimer = 0f;
                        }
 
                        bool otherDynamic = other.Body != null && other.Body.IsAwake;
 
                        float invMA = 1f / a.Body.Mass;
                        float invMB = otherDynamic ? 1f / other.Body!.Mass : 0f;
                        float total = invMA + invMB;
                        if (total > 0f)
                        {
                            float corrDepth = Math.Max(depth - 0.005f, 0f);
                            a.Position = a.Position + normal * (corrDepth * invMA / total);
                            if (otherDynamic)
                                other.Position = other.Position - normal * (corrDepth * invMB / total);
                        }
 
                        Vec3 contactPt = DeepestVertex(a, normal * -1f);
                        Vec3 comWorld  = a.Position + RotateByObject(a, a.Body.CenterOfMass);
                        Vec3 rA        = contactPt - comWorld;
 
                        Vec3 velAtContact = a.Body.LinearVelocity + Vec3.Cross(a.Body.AngularVelocity, rA);
                        Vec3 velB         = otherDynamic ? other.Body!.LinearVelocity : new Vec3(0,0,0);
                        float relVel      = Vec3.Dot(velAtContact - velB, normal);
                        if (relVel > 0f) continue;
 
                        float e = otherDynamic
                            ? (a.Body.Restitution + other.Body!.Restitution) * 0.5f
                            : a.Body.Restitution;
                        if (MathF.Abs(relVel) < 2.0f) e = 0f;
 
                        Vec3  rAxN     = Vec3.Cross(rA, normal);
                        float angMassA = Vec3.Dot(rAxN, new Vec3(
                            rAxN.X / a.Body.InertiaTensor.X,
                            rAxN.Y / a.Body.InertiaTensor.Y,
                            rAxN.Z / a.Body.InertiaTensor.Z));
                        float impJ   = -(1f + e) * relVel / (invMA + invMB + angMassA);
                        Vec3 impulse = normal * impJ;
 
                        a.Body.LinearVelocity = a.Body.LinearVelocity + impulse * invMA;
                        if (otherDynamic)
                            other.Body!.LinearVelocity = other.Body.LinearVelocity - impulse * invMB;
 
                        Vec3 torqueImp = Vec3.Cross(rA, impulse);
                        a.Body.AngularVelocity = a.Body.AngularVelocity + new Vec3(
                            torqueImp.X / a.Body.InertiaTensor.X,
                            torqueImp.Y / a.Body.InertiaTensor.Y,
                            torqueImp.Z / a.Body.InertiaTensor.Z);
 
                        Vec3  tangent = (velAtContact - velB) - normal * relVel;
                        float tLen    = MathF.Sqrt(Vec3.Dot(tangent, tangent));
                        if (tLen > 1e-4f)
                        {
                            tangent = tangent * (1f / tLen);
                            Vec3  rAxT     = Vec3.Cross(rA, tangent);
                            float angMassT = Vec3.Dot(rAxT, new Vec3(
                                rAxT.X / a.Body.InertiaTensor.X,
                                rAxT.Y / a.Body.InertiaTensor.Y,
                                rAxT.Z / a.Body.InertiaTensor.Z));
                            float jt  = -Vec3.Dot(velAtContact - velB, tangent) / (invMA + invMB + angMassT);
                            float mu  = a.Body.Friction * (otherDynamic ? other.Body!.Friction : 0.6f);
                            jt = Math.Clamp(jt, -MathF.Abs(impJ) * mu, MathF.Abs(impJ) * mu);
                            Vec3 ftImp = tangent * jt;
                            a.Body.LinearVelocity  = a.Body.LinearVelocity  + ftImp * invMA;
                            Vec3 ftTorque = Vec3.Cross(rA, ftImp);
                            a.Body.AngularVelocity = a.Body.AngularVelocity + new Vec3(
                                ftTorque.X / a.Body.InertiaTensor.X,
                                ftTorque.Y / a.Body.InertiaTensor.Y,
                                ftTorque.Z / a.Body.InertiaTensor.Z);
                        }
 
                        if (otherDynamic) other.Body!.IsAwake = true;
                        a.Body.SleepTimer = 0f;
                    }
                }
            }
        }
 
        foreach (var obj in scene)
        {
            var b = obj.Body;
            if (b == null || !b.IsAwake) continue;
 
            float spd2 = Vec3.Dot(b.LinearVelocity,  b.LinearVelocity);
            float ang2 = Vec3.Dot(b.AngularVelocity, b.AngularVelocity);
 
            if (spd2 < 0.04f && ang2 < 0.04f)
            {
                b.SleepTimer += dt;
                if (b.SleepTimer > 0.5f)
                {
                    b.IsAwake         = false;
                    b.SleepTimer      = 0f;
                    b.LinearVelocity  = new(0,0,0);
                    b.AngularVelocity = new(0,0,0);
                }
            }
            else
            {
                b.SleepTimer = 0f;
            }
        }
    }
 
    static Vec3 RotateByObject(SceneObject obj, Vec3 v)
    {
        if (obj.RotX!=0f){ float c=MathF.Cos(obj.RotX),s=MathF.Sin(obj.RotX); v=new(v.X,c*v.Y-s*v.Z,s*v.Y+c*v.Z); }
        if (obj.RotY!=0f){ float c=MathF.Cos(obj.RotY),s=MathF.Sin(obj.RotY); v=new(c*v.X+s*v.Z,v.Y,-s*v.X+c*v.Z); }
        if (obj.RotZ!=0f){ float c=MathF.Cos(obj.RotZ),s=MathF.Sin(obj.RotZ); v=new(c*v.X-s*v.Y,s*v.X+c*v.Y,v.Z); }
        return v;
    }
 
    static Vec3 DeepestVertex(SceneObject obj, Vec3 direction)
    {
        Vec3  best  = obj.LocalToWorld(obj.Mesh.Verts[0]);
        float bestD = Vec3.Dot(best, direction);
        for (int vi = 1; vi < obj.Mesh.Verts.Length; vi++)
        {
            Vec3  w = obj.LocalToWorld(obj.Mesh.Verts[vi]);
            float d = Vec3.Dot(w, direction);
            if (d > bestD) { bestD = d; best = w; }
        }
        return best;
    }
 
    public static SceneObject? Raycast(
        Vec3 origin, Vec3 direction, float maxLength,
        IEnumerable<SceneObject> scene)
    {
        Vec3 dir=direction.Normalised();
        float closest=maxLength;
        SceneObject? result=null;
        foreach (var obj in scene)
        {
            GetAABB(obj, out Vec3 bmin, out Vec3 bmax);
            if (RayAABB(origin,dir,bmin,bmax,out float dist)&&dist<closest)
            { closest=dist; result=obj; }
        }
        return result;
    }
 
    public static bool RaycastOne(
        Vec3 origin, Vec3 direction, float maxLength,
        SceneObject obj, out float distance, out Vec3 hitPoint)
    {
        Vec3 dir=direction.Normalised();
        GetAABB(obj, out Vec3 bmin, out Vec3 bmax);
        if (RayAABB(origin,dir,bmin,bmax,out distance)&&distance<=maxLength)
        { hitPoint=origin+dir*distance; return true; }
        hitPoint=default; return false;
    }
 
    public static bool Overlaps(SceneObject a, SceneObject b)
    {
        GetAABB(a, out Vec3 amin, out Vec3 amax);
        GetAABB(b, out Vec3 bmin, out Vec3 bmax);
        return AABBOverlap(amin,amax,bmin,bmax);
    }
 
    public static bool OverlapAmount(SceneObject a, SceneObject b,
                                     out Vec3 normal, out float depth)
    {
        GetAABB(a, out Vec3 amin, out Vec3 amax);
        GetAABB(b, out Vec3 bmin, out Vec3 bmax);
        return AABBPenetration(amin,amax,bmin,bmax,out normal,out depth);
    }
 
    public static List<(SceneObject a, SceneObject b)> CheckCollisions(
        IReadOnlyList<SceneObject> scene)
    {
        var hits=new List<(SceneObject,SceneObject)>();
        for (int i=0;i<scene.Count;i++)
        for (int j=i+1;j<scene.Count;j++)
            if (Overlaps(scene[i],scene[j])) hits.Add((scene[i],scene[j]));
        return hits;
    }
 
    public static void ResolveCollision(SceneObject mover, IEnumerable<SceneObject> others)
    {
        foreach (var other in others)
        {
            if (ReferenceEquals(mover,other)) continue;
            GetAABB(mover, out Vec3 mmin, out Vec3 mmax);
            GetAABB(other, out Vec3 omin, out Vec3 omax);
            if (AABBPenetration(mmin,mmax,omin,omax,out Vec3 normal,out float depth))
                mover.Position=mover.Position+normal*depth;
        }
    }
 
    public static Vec3 MoveAndCollide(SceneObject mover, Vec3 velocity,
                                      float dt, IEnumerable<SceneObject> others)
    {
        mover.Position=mover.Position+velocity*dt;
        foreach (var other in others)
        {
            if (ReferenceEquals(mover,other)) continue;
            bool hasRot=other.RotX!=0f||other.RotY!=0f||other.RotZ!=0f;
            Vec3 normal; float depth;
            if (!hasRot)
            {
                GetAABB(mover, out Vec3 mmin, out Vec3 mmax);
                GetAABB(other, out Vec3 omin, out Vec3 omax);
                if (!AABBPenetration(mmin,mmax,omin,omax,out normal,out depth)) continue;
            }
            else
            {
                if (!LocalSpacePenetration(mover,other,out normal,out depth)) continue;
            }
            mover.Position=mover.Position+normal*depth;
            float vDotN=Vec3.Dot(velocity,normal);
            if (vDotN<0f) velocity=velocity-normal*vDotN;
        }
        return velocity;
    }
 
    public static void GetAABB(SceneObject obj, out Vec3 bmin, out Vec3 bmax)
    {
        float minX=float.MaxValue,minY=float.MaxValue,minZ=float.MaxValue;
        float maxX=float.MinValue,maxY=float.MinValue,maxZ=float.MinValue;
        foreach (var v in obj.Mesh.Verts)
        {
            Vec3 w=obj.LocalToWorld(v);
            if (w.X<minX) minX=w.X; if (w.X>maxX) maxX=w.X;
            if (w.Y<minY) minY=w.Y; if (w.Y>maxY) maxY=w.Y;
            if (w.Z<minZ) minZ=w.Z; if (w.Z>maxZ) maxZ=w.Z;
        }
        bmin=new Vec3(minX,minY,minZ);
        bmax=new Vec3(maxX,maxY,maxZ);
    }
 
    static bool LocalSpacePenetration(SceneObject mover, SceneObject other,
                                       out Vec3 worldNormal, out float depth)
    {
        worldNormal=default; depth=0f;
        GetAABB(mover, out Vec3 mmin, out Vec3 mmax);
        Vec3 mCW=new Vec3((mmin.X+mmax.X)*.5f,(mmin.Y+mmax.Y)*.5f,(mmin.Z+mmax.Z)*.5f);
        Vec3 mH =new Vec3((mmax.X-mmin.X)*.5f,(mmax.Y-mmin.Y)*.5f,(mmax.Z-mmin.Z)*.5f);
        Vec3 lc =other.WorldToLocal(mCW);
        float r =Math.Max(mH.X,Math.Max(mH.Y,mH.Z));
        other.GetLocalAABB(out Vec3 omin, out Vec3 omax);
        float ox=Math.Min(lc.X+r,omax.X)-Math.Max(lc.X-r,omin.X);
        float oy=Math.Min(lc.Y+r,omax.Y)-Math.Max(lc.Y-r,omin.Y);
        float oz=Math.Min(lc.Z+r,omax.Z)-Math.Max(lc.Z-r,omin.Z);
        if (ox<=0f||oy<=0f||oz<=0f) return false;
        Vec3 oc=new Vec3((omin.X+omax.X)*.5f,(omin.Y+omax.Y)*.5f,(omin.Z+omax.Z)*.5f);
        Vec3 ln;
        if (ox<=oy&&ox<=oz) { depth=ox; ln=new Vec3(lc.X>oc.X?1f:-1f,0f,0f); }
        else if (oy<=ox&&oy<=oz) { depth=oy; ln=new Vec3(0f,lc.Y>oc.Y?1f:-1f,0f); }
        else { depth=oz; ln=new Vec3(0f,0f,lc.Z>oc.Z?1f:-1f); }
        Vec3 n=ln;
        if (other.RotX!=0f){ float c=MathF.Cos(other.RotX),s=MathF.Sin(other.RotX); n=new(n.X,c*n.Y-s*n.Z,s*n.Y+c*n.Z); }
        if (other.RotY!=0f){ float c=MathF.Cos(other.RotY),s=MathF.Sin(other.RotY); n=new(c*n.X+s*n.Z,n.Y,-s*n.X+c*n.Z); }
        if (other.RotZ!=0f){ float c=MathF.Cos(other.RotZ),s=MathF.Sin(other.RotZ); n=new(c*n.X-s*n.Y,s*n.X+c*n.Y,n.Z); }
        worldNormal=n.Normalised();
        return true;
    }
 
    static bool AABBOverlap(Vec3 amin, Vec3 amax, Vec3 bmin, Vec3 bmax)
        => amin.X<=bmax.X&&amax.X>=bmin.X&&amin.Y<=bmax.Y&&amax.Y>=bmin.Y&&amin.Z<=bmax.Z&&amax.Z>=bmin.Z;
 
    static bool AABBPenetration(Vec3 amin, Vec3 amax, Vec3 bmin, Vec3 bmax,
                                 out Vec3 normal, out float depth)
    {
        normal=default; depth=0f;
        float ox=Math.Min(amax.X,bmax.X)-Math.Max(amin.X,bmin.X);
        float oy=Math.Min(amax.Y,bmax.Y)-Math.Max(amin.Y,bmin.Y);
        float oz=Math.Min(amax.Z,bmax.Z)-Math.Max(amin.Z,bmin.Z);
        if (ox<=0f||oy<=0f||oz<=0f) return false;
        Vec3 ac=new Vec3((amin.X+amax.X)*.5f,(amin.Y+amax.Y)*.5f,(amin.Z+amax.Z)*.5f);
        Vec3 bc=new Vec3((bmin.X+bmax.X)*.5f,(bmin.Y+bmax.Y)*.5f,(bmin.Z+bmax.Z)*.5f);
        if (ox<=oy&&ox<=oz){ depth=ox; normal=new Vec3(ac.X>bc.X?1f:-1f,0f,0f); }
        else if (oy<=ox&&oy<=oz){ depth=oy; normal=new Vec3(0f,ac.Y>bc.Y?1f:-1f,0f); }
        else { depth=oz; normal=new Vec3(0f,0f,ac.Z>bc.Z?1f:-1f); }
        return true;
    }
 
    static bool RayAABB(Vec3 ro, Vec3 rd, Vec3 bmin, Vec3 bmax, out float dist)
    {
        dist=0f;
        float invX=MathF.Abs(rd.X)>1e-7f?1f/rd.X:float.MaxValue;
        float invY=MathF.Abs(rd.Y)>1e-7f?1f/rd.Y:float.MaxValue;
        float invZ=MathF.Abs(rd.Z)>1e-7f?1f/rd.Z:float.MaxValue;
        float tx1=(bmin.X-ro.X)*invX,tx2=(bmax.X-ro.X)*invX;
        float ty1=(bmin.Y-ro.Y)*invY,ty2=(bmax.Y-ro.Y)*invY;
        float tz1=(bmin.Z-ro.Z)*invZ,tz2=(bmax.Z-ro.Z)*invZ;
        float tmin=Math.Max(Math.Max(Math.Min(tx1,tx2),Math.Min(ty1,ty2)),Math.Min(tz1,tz2));
        float tmax=Math.Min(Math.Min(Math.Max(tx1,tx2),Math.Max(ty1,ty2)),Math.Max(tz1,tz2));
        if (tmax<0f||tmin>tmax) return false;
        dist=tmin>=0f?tmin:tmax;
        return true;
    }
}
public class Gametest
{
    public static double rampL(double leng, double heig)
    {
        double b=Math.Sqrt((leng*leng)+(heig*heig)-2*(leng*heig)*Math.Cos(90));
        return b;
    }
    public static double rampWinkel(double leng, double heig, double b)
    {
        double g=((Math.Sin(90)/(b))*5);
        double f=Math.Asin(g)*(180/Math.PI);
        return f;
    }
    public static double c(double leng, double heig)
    {
        double c=Math.Sqrt((leng*leng)+(heig*heig));
        return c;
    }
}

public class RandomAhhhMeshshit
{
    public static Mesh GenerateSphereMesh(int longitudeSegments, int latitudeSegments, float radius)
    {
        var verts = new List<Vec3>();

        verts.Add(new Vec3(0f, radius, 0f));

        for (int j = 1; j < latitudeSegments; j++)
        {
            float phi = MathF.PI * j / latitudeSegments;
            float y = radius * MathF.Cos(phi);
            float ringR = radius * MathF.Sin(phi);

            for (int i = 0; i < longitudeSegments; i++)
            {
                float theta = 2f * MathF.PI * i / longitudeSegments;
                float x = ringR * MathF.Cos(theta);
                float z = ringR * MathF.Sin(theta);
                verts.Add(new Vec3(x, y, z));
            }
        }

        verts.Add(new Vec3(0f, -radius, 0f));

        int topIdx = 0;
        int botIdx = verts.Count - 1;

        var faces = new List<(int, int, int, int, float)>();

        for (int i = 0; i < longitudeSegments; i++)
        {
            int a = 1 + i;
            int b = 1 + (i + 1) % longitudeSegments;
            faces.Add((topIdx, b, a, a, 0.0f));
        }

        for (int j = 0; j < latitudeSegments - 2; j++)
        {
            for (int i = 0; i < longitudeSegments; i++)
            {
                int row = 1 + j * longitudeSegments;
                int a = row + i;
                int b = row + (i + 1) % longitudeSegments;
                int c = row + longitudeSegments + (i + 1) % longitudeSegments;
                int d = row + longitudeSegments + i;
                faces.Add((a, b, c, d, -0.1f));
            }
        }

        int lastRingStart = 1 + (latitudeSegments - 2) * longitudeSegments;
        for (int i = 0; i < longitudeSegments; i++)
        {
            int a = lastRingStart + i;
            int b = lastRingStart + (i + 1) % longitudeSegments;
            faces.Add((a, botIdx, botIdx, b, 0.0f));
        }

        return new Mesh(verts.ToArray(), faces.ToArray());
    }
}
