# Contributing to SpleeterGui

Thank you for your interest in contributing to SpleeterGui! This document provides guidelines for contributing to the modernized version of the project.

## 🎯 **Project Vision**

SpleeterGui aims to provide a beautiful, modern, and user-friendly Windows desktop interface for AI-powered music source separation. The modernized version focuses on:

- **Pixel-perfect UI design** with professional appearance
- **Streamlined user experience** with logical workflow
- **Modern development practices** and clean code
- **Accessibility** and ease of use for all users

## 🛠️ **Development Setup**

### Prerequisites
- **Visual Studio 2019/2022** or **Visual Studio Code** with C# extension
- **.NET Framework 4.8** SDK
- **Git** for version control
- **Windows 10/11** for testing

### Getting Started
```bash
# Clone the repository
git clone <repository-url>
cd SpleeterGui

# Open in Visual Studio
start SpleeterGui.sln

# Or build from command line
dotnet build SpleeterGui.sln
```

### Project Structure
```
SpleeterGui/
├── SpleeterGui/              # Main C# application
│   ├── Form1.cs             # Main form logic
│   ├── Form1.Designer.cs    # UI layout and controls
│   ├── Program.cs           # Application entry point
│   └── Properties/          # Assembly info and resources
├── languages_source/        # Language files (EN, VI, KO only)
├── README.md               # Project documentation
├── CHANGELOG.md            # Version history
└── CONTRIBUTING.md         # This file
```

## 🎨 **UI Design Guidelines**

### Visual Standards
- **High-Quality Rendering**: Always use `SmoothingMode.HighQuality` and related settings
- **Consistent Styling**: Follow the established dark theme and color palette
- **Pixel-Perfect**: Ensure crisp edges and smooth curves
- **Professional Appearance**: Maintain enterprise-grade visual quality

### Color Palette
```csharp
// Primary colors
Color.FromArgb(45, 45, 48)    // Background
Color.FromArgb(62, 62, 66)    // Controls
Color.FromArgb(0, 122, 204)   // Accent
Color.White                   // Text
Color.FromArgb(200, 200, 200) // Secondary text
```

### Custom Controls
When creating custom controls:
- Inherit from `Control` class
- Implement proper `OnPaint` methods
- Use `GraphicsPath` for rounded rectangles
- Add hover effects and animations
- Ensure accessibility compliance

## 🌐 **Language Support**

### Supported Languages
The modernized version supports exactly **3 languages**:
- **English** (en) - Default
- **Vietnamese** (vi) - Tiếng Việt
- **Korean** (ko) - 한국어

### Adding Translations
1. **DO NOT** add new languages without discussion
2. Update existing translations in `languages_source/`
3. Follow the XML structure of existing files
4. Test all UI elements with new translations
5. Ensure text fits within UI controls

### Language File Format
```xml
<?xml version="1.0" encoding="utf-8" ?>
<root>
    <language english="language_name" control="">language_name</language>
    <item english="English text" control="control_name">Translated text</item>
    <!-- ... more items ... -->
</root>
```

## 🔧 **Code Standards**

### C# Coding Style
- Use **PascalCase** for public members
- Use **camelCase** for private fields
- Add **XML documentation** for public methods
- Follow **Microsoft C# conventions**

### Graphics Programming
```csharp
// Example of proper graphics setup
protected override void OnPaint(PaintEventArgs e)
{
    Graphics g = e.Graphics;
    g.SmoothingMode = SmoothingMode.HighQuality;
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    g.CompositingQuality = CompositingQuality.HighQuality;
    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    
    // Your drawing code here
}
```

### Performance Considerations
- **Dispose graphics objects** properly using `using` statements
- **Cache brushes and pens** when possible
- **Minimize paint operations** in frequently called methods
- **Use double buffering** for smooth animations

## 🧪 **Testing**

### Manual Testing
- Test on **Windows 10** and **Windows 11**
- Verify all **3 languages** work correctly
- Test **drag and drop** functionality
- Verify **file processing** with various audio formats
- Check **UI responsiveness** and visual quality

### UI Testing Checklist
- [ ] All buttons have hover effects
- [ ] Language dropdown works correctly
- [ ] Text is readable in all languages
- [ ] No visual artifacts or jagged edges
- [ ] Proper scaling on different DPI settings

## 📝 **Pull Request Process**

### Before Submitting
1. **Test thoroughly** on Windows 10/11
2. **Update documentation** if needed
3. **Follow coding standards**
4. **Check for visual regressions**

### PR Description Template
```markdown
## Description
Brief description of changes

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] UI improvement
- [ ] Documentation update

## Testing
- [ ] Tested on Windows 10
- [ ] Tested on Windows 11
- [ ] All languages work correctly
- [ ] No visual regressions

## Screenshots
(If UI changes, include before/after screenshots)
```

## 🚫 **What NOT to Contribute**

### Prohibited Changes
- **Adding new languages** (only EN, VI, KO supported)
- **Bringing back the menu bar** (intentionally removed)
- **Adding old URL references** (cleaned for independence)
- **Reverting UI modernizations** (pixel-perfect design is core)
- **Adding dependencies** without discussion

### Discouraged Changes
- Major architectural changes without prior discussion
- UI changes that break the modern design language
- Performance regressions
- Accessibility violations

## 🆘 **Getting Help**

### Resources
- **README.md**: Project overview and setup
- **CHANGELOG.md**: Recent changes and version history
- **Source Code**: Well-commented code with examples

### Questions
For questions about contributing:
1. Check existing documentation
2. Review the source code
3. Open an issue for discussion

## 📄 **License**

By contributing to SpleeterGui, you agree that your contributions will be licensed under the same license as the project (Apache License 2.0).

---

Thank you for helping make SpleeterGui better! 🎵
