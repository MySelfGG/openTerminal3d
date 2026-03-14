#!/bin/bash

# Check if a path argument was provided
if [ -z "$1" ]; then
  echo "Usage: $0 <path-to-csproj>"
  exit 1
fi

PROJECT_PATH="$1"

dotnet publish "$PROJECT_PATH" -c Release -r linux-x64 --self-contained true