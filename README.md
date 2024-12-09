# Mandelbrot Set Visualizer in Unity

This project is an interactive Mandelbrot set visualizer built in Unity. It uses a custom shader for rendering the fractal and a controller script for navigation, allowing dynamic zooming, panning, and iteration adjustments.

---

## 🎨 **Features**
- **Real-Time Exploration**:
  - Smooth zooming using the mouse scroll wheel.
  - Adjustable panning speed based on zoom level for fine control.
- **Customizable Detail**:
  - Dynamic iteration count adjustment for balancing performance and detail.
  - Grayscale rendering for a clean and elegant aesthetic.
- **Interactive Navigation**:
  - Intuitive keyboard and mouse controls for seamless fractal exploration.
- **Reset Functionality**:
  - Quickly reset the view to the default position, zoom level, and iteration count.

---

## 🖥️ **Technologies Used**
- **Unity Engine** (Version X.X or higher)
- **HLSL** (High-Level Shader Language)
- **C# Scripts** for user interaction and parameter control

---

## 🚀 **Getting Started**

### Prerequisites
- Unity Editor (Version X.X or later)
- Basic understanding of Unity projects

### Installation
1. Clone this repository:
   ```bash
   git clone https://github.com/your-username/mandelbrot-visualizer.git
   cd mandelbrot-visualizer
   ```
2. Open the project in Unity.
3. Attach the **MandelbrotController** script to a GameObject in your scene.
4. Create a Plane or Quad and assign the Mandelbrot material to it.

---

## 🎮 **Controls**

| **Action**         | **Input**               |
|---------------------|-------------------------|
| Zoom               | Scroll mouse wheel      |
| Pan (Move)         | `W`, `A`, `S`, `D`      |
| Increase Iterations | `+` or `=` key          |
| Decrease Iterations | `-` or `_` key          |
| Reset View         | `R` key                 |

---

## 🛠️ **Customization**

### Parameters (Exposed in Unity Inspector)
- **Base Pan Speed**: Controls the default speed of panning.
- **Zoom Speed**: Sensitivity of zooming with the mouse scroll wheel.
- **Pan Scaling Exponent**: Adjusts how panning slows down with zoom.
  - Example: Set to `2.0` for quadratic scaling or `3.0` for cubic scaling.
- **Min/Max Iterations**: Bounds for iteration adjustments.
- **Iteration Step**: Controls how much the iteration count changes with `+` or `-`.

---

## 🧠 **How It Works**

### Mandelbrot Shader
The shader computes the Mandelbrot fractal by iterating the formula:
\[ Z_{n+1} = Z_n^2 + C \]
- For each pixel, the shader determines the number of iterations before the value escapes a threshold (e.g., magnitude > 2).
- The iteration count is normalized and used to generate grayscale values.

### Controller Script
- **Dynamic Zoom and Pan**: Adjusts the fractal’s `_Zoom` and `_Offset` parameters.
- **Iteration Control**: Updates the `_MaxIterations` parameter to refine fractal detail.
- **Smooth Navigation**: Panning speed scales based on the zoom level for fine control during deep zooms.

---

## 🌟 **Future Enhancements**
- **Color Mapping**: Add support for customizable color gradients.
- **Julia Sets**: Enable rendering of related fractals with a toggle.
- **Save/Export**: Allow users to save their favorite fractal views as images.

---

## 🤝 **Contributing**
Contributions are welcome! Feel free to open issues or submit pull requests to improve this project.

---

## 📧 **Contact**
If you have questions or feedback, feel free to reach out:
- **Email**: jadoo@berkeley.edu
- **GitHub**: [KTK-Jadoo](https://github.com/KTK-Jadoo)

---

Feel free to adjust this README with your actual repository details, such as screenshots, GitHub username, and contact information. Let me know if you'd like help with anything else! 😊
