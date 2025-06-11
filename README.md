## SpleeterGUI - Music Source Separation Desktop App
**Modernized Edition with Pixel-Perfect UI**

A beautiful, modern Windows desktop application for AI-powered music source separation using Spleeter technology. This modernized version features a completely redesigned interface with pixel-perfect rendering, custom controls, and streamlined workflow.

### 🎯 **Key Features**
- **Modern UI**: Pixel-perfect custom controls with anti-aliasing and professional styling
- **Custom Language Dropdown**: Beautiful globe-icon dropdown supporting 3 languages
- **Streamlined Interface**: Removed cluttered menus for a clean, focused experience
- **Logical Workflow**: Output folder selection before music file selection
- **Portable**: No Python installation required - everything is included

### 🌐 **Language Support**
- **English** (Default)
- **Vietnamese** (Tiếng Việt)
- **Korean** (한국어)

![SpleeterGUI_app](/Spleeter_GUI.png)

### 🚀 **What's New in This Modernized Version**
This is a complete modernization of the original SpleeterGUI with focus on user experience and visual design.

## 🎨 **Modernization Features**

### **Visual Enhancements**
- ✅ **Pixel-Perfect Rendering**: High-quality anti-aliased graphics with `SmoothingMode.HighQuality`
- ✅ **Custom Language Dropdown**: Beautiful globe icon with gradient backgrounds and hover effects
- ✅ **Professional Styling**: Modern color schemes, rounded corners, and shadow effects
- ✅ **Streamlined Layout**: Removed cluttered menu bar for clean, focused interface
- ✅ **Logical Workflow**: Output folder selection appears before music file selection

### **Technical Improvements**
- ✅ **Menu Removal**: Eliminated File/Language/Advanced/Help menu bar
- ✅ **Language Cleanup**: Reduced from 13 to 3 languages (English, Vietnamese, Korean)
- ✅ **URL Cleanup**: Removed all references to old project ownership and URLs
- ✅ **Modern Controls**: Custom-drawn controls with advanced graphics rendering
- ✅ **Responsive Design**: Hover effects, animations, and visual feedback

## 📋 **Version History**

| Date | Version | Notes |
| ----: |:-------:| ----- |
| **June 2025** | **2.9.5 (Modernized)** | **🎨 Complete UI modernization, pixel-perfect rendering, custom language dropdown, streamlined workflow** |
| 7/10/2023 | 2.9.5 | Rebuilt with python 3.10.10 and spleeter 2.4. Updated GUI |
| 5/04/2022 | 2.9.2 | Upgraded spleeter to 2.3.0. Updated python files |
| 30/01/2021 | 2.9.1 | Upgraded spleeter to 2.1.2. Updated command syntax |
| 9/11/2020 | 2.9 | Upgraded spleeter to 2.0.1 and python |
| 31/07/2020 | 2.8 | Upgraded the project to 64bit |
  

## 🚀 **Getting Started**

### **System Requirements**
- Windows 10/11 (64-bit)
- .NET Framework 4.8 or higher
- 4GB RAM minimum (8GB recommended)
- 2GB free disk space

### **Installation**
1. Download the latest release from the releases section
2. Extract all files to a folder of your choice
3. Run `SpleeterGui.exe`
4. No additional installation required - all dependencies included!

### **Usage**
1. **Select separation mode**: Choose 2, 4, or 5 stems
2. **Choose output folder**: Click "📂 Output Folder" (appears first for logical workflow)
3. **Select music files**: Drag & drop or click "📁 Browse for Files"
4. **Processing begins automatically**: Separated files saved to your chosen directory

## 🎵 **Separation Modes**
- **2 stems**: Vocal + Accompaniment
- **4 stems**: Vocal + Bass + Drums + Other
- **5 stems**: Vocal + Bass + Drums + Piano + Other

## 🎨 **Features**
- **Modern UI**: Pixel-perfect custom controls with professional styling
- **Multi-language**: English, Vietnamese, Korean with beautiful dropdown
- **Drag & Drop**: Simply drop music files to start processing
- **Batch Processing**: Handle multiple files at once
- **High Quality**: 16kHz full bandwidth mode available
- **Portable**: Complete Python 3.10 + Spleeter 2.4 environment included

## 🛠️ **Development**

### **Building from Source**
```bash
# Clone the repository
git clone <repository-url>
cd SpleeterGui

# Build Debug version
dotnet build SpleeterGui.sln

# Build Release version
msbuild SpleeterGui.sln /p:Configuration=Release
```

### **Project Structure**
```
SpleeterGui/
├── SpleeterGui/              # Main C# application
│   ├── Form1.cs             # Main form with modern UI
│   ├── Form1.Designer.cs    # UI layout and controls
│   └── languages_source/    # Language files (EN, VI, KO)
├── configs/                 # Spleeter configuration files
├── pretrained_models/       # AI models for separation
└── python/                  # Portable Python 3.10 environment
```

### **Technical Details**
- **Framework**: .NET Framework 4.8
- **Platform**: x64 (64-bit)
- **UI**: Windows Forms with custom rendering
- **Graphics**: High-quality anti-aliased rendering
- **Python**: Portable Python 3.10.10
- **Spleeter**: Version 2.4
- **Audio Processing**: FFmpeg included

## 🎬 **Demo Videos**
- [Vocal Isolation Demo](https://www.youtube.com/watch?v=bdNzVPLzOLE)
- [4-Stem Separation](https://www.youtube.com/watch?v=nxJfIsus0Ig)
- [5-Stem Advanced Mode](https://www.youtube.com/watch?v=PHGAmZhuI-c)

## 📄 **License**
This software is provided under the Apache License 2.0. See the original Spleeter project for AI model licensing information.

## 🙏 **Credits**
- **Spleeter AI Models**: [Deezer Research](https://github.com/deezer/spleeter)
- **Modern UI Design**: Pixel-perfect rendering and custom controls
- **Multi-language Support**: English, Vietnamese, Korean translations
- **Portable Environment**: Python 3.10 + dependencies integration
