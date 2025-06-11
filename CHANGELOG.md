# Changelog

All notable changes to SpleeterGui will be documented in this file.

## [2.9.5 Modernized Edition] - 2025-06-11

### 🎨 **Major UI Modernization**

#### Added
- **Custom Language Dropdown**: Beautiful pixel-perfect dropdown with globe icon
  - Gradient backgrounds with hover effects
  - Professional styling with rounded corners and shadows
  - High-quality anti-aliased rendering
  - Smooth animations and visual feedback
- **Pixel-Perfect Graphics**: Maximum quality rendering throughout the application
  - `SmoothingMode.HighQuality` for smooth curves
  - `PixelOffsetMode.HighQuality` for crisp edges
  - `CompositingQuality.HighQuality` for professional appearance
  - `TextRenderingHint.ClearTypeGridFit` for crystal clear text
- **Modern Button Styling**: Enhanced buttons with hover effects and gradients
- **Logical Workflow**: Output folder selection now appears before music file selection

#### Changed
- **Streamlined Interface**: Completely removed File/Language/Advanced/Help menu bar
- **Language Support**: Reduced from 13 languages to 3 (English, Vietnamese, Korean)
- **Panel Layout**: Swapped positions of output and input panels for better user flow
- **Visual Design**: Modern dark theme with professional color scheme
- **Header Layout**: Moved header panel to Y=0, gained 32px of vertical space

#### Removed
- **Menu Bar**: Eliminated entire MenuStrip for cleaner interface
- **10 Language Files**: Removed Arabic, Chinese, French, German, Hindi, Italian, Japanese, Russian, Spanish, Traditional Chinese
- **Old URL References**: Removed all references to `github.com/boy1dr` and `makenweb.com/spleeter_help.php`
- **Old Branding**: Cleaned all references to previous project ownership
- **Cluttered UI Elements**: Simplified interface for better user experience

### 🔧 **Technical Improvements**

#### Enhanced
- **Custom Controls**: Implemented `CustomLanguageDropdown` and `CustomLanguageDropdownList` classes
- **Graphics Rendering**: Advanced rendering with multiple gradient layers and effects
- **Code Organization**: Cleaner code structure with modernized methods
- **Build Process**: Updated project files and dependencies

#### Fixed
- **Language Loading**: Improved language file loading and error handling
- **UI Responsiveness**: Better performance with optimized rendering
- **Memory Usage**: More efficient graphics operations

### 🌐 **Language Changes**

#### Updated Language Files
- **English**: Replaced old URLs with "Music Source Separation Tool"
- **Vietnamese**: Updated with "Công cụ tách nguồn âm nhạc"
- **Korean**: Updated with "음원 분리 도구"

#### Removed Languages
- Arabic, Chinese (Simplified), French, German, Hindi, Italian, Japanese, Russian, Spanish, Chinese (Traditional)

### 📦 **Release Package**

#### Included
- **Complete Release Build**: Optimized x64 executable
- **Updated Documentation**: README.txt and VERSION.txt with modernization details
- **Clean Language Files**: Only 3 languages without old URL references
- **Portable Environment**: Python 3.10 + Spleeter 2.4 + all dependencies

### 🎯 **User Experience**

#### Improved Workflow
1. **Step 1**: Select separation mode (2, 4, or 5 stems)
2. **Step 2**: Choose output folder (logical first step)
3. **Step 3**: Select music files (after output is set)
4. **Step 4**: Automatic processing begins

#### Visual Enhancements
- Professional appearance suitable for end users
- Intuitive interface with clear visual hierarchy
- Modern design patterns and user expectations
- Consistent theming throughout the application

---

## [2.9.5] - 2023-10-07

### Changed
- Rebuilt with Python 3.10.10 and Spleeter 2.4
- Updated GUI components
- New website: spleetergui.com

## [2.9.2] - 2022-04-05

### Changed
- Upgraded Spleeter to 2.3.0
- Updated Python files
- Spleeter core update feature working again

## [2.9.1] - 2021-01-30

### Changed
- Upgraded Spleeter to 2.1.2
- Updated command syntax for latest Spleeter version

## [2.9] - 2020-11-09

### Changed
- Upgraded Spleeter to 2.0.1
- Updated Python environment

## [2.8] - 2020-07-31

### Changed
- Upgraded project to 64-bit architecture

---

*For older version history, see the original project documentation.*
