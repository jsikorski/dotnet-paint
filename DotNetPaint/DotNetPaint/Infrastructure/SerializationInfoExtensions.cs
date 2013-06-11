using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace DotNetPaint.Infrastructure
{
    public static class SerializationInfoExtensions
    {
        private const string ColorArgbSuffix = ".Argb";

        private const string PenColorArgbSuffix = ".Color";
        private const string PenWidthSuffix = ".Width";
        private const string PenDashStyleSuffix = ".DashStyle";

        private const string BrushTypeSuffix = ".Type";
        private const string SolidBrushType = "Solid";
        private const string LinearGradientBrushType = "LinearGradient";

        private const string SolidBrushColorSuffix = ".Color";
        
        private const string LinearGradientRectangleSuffix = ".Ractangle";
        private const string LinearGradientFirstColorSuffix = ".FirstColor";
        private const string LinearGradientSecondColorSuffix = ".SecondColor";

        private const string RectangleXSuffix = ".X";
        private const string RectangleYSuffix = ".Y";
        private const string RectangleWidthSuffix = ".Width";
        private const string RectangleHeightSuffix = ".Height";



        public static T GetValue<T>(this SerializationInfo info, string name)
        {
            return (T)info.GetValue(name, typeof(T));
        }



        public static void AddColor(this SerializationInfo info, string name, Color color)
        {
            info.AddValue(name + ColorArgbSuffix, color.ToArgb());
        }

        public static Color GetColor(this SerializationInfo info, string name)
        {
            return Color.FromArgb(info.GetInt32(name + ColorArgbSuffix));
        }



        public static void AddPen(this SerializationInfo info, string name, Pen pen)
        {
            info.AddColor(name + PenColorArgbSuffix, pen.Color);
            info.AddValue(name + PenWidthSuffix, pen.Width);
            info.AddValue(name + PenDashStyleSuffix, pen.DashStyle);
        }

        public static Pen GetPen(this SerializationInfo info, string name)
        {
            var penColor = info.GetColor(name + PenColorArgbSuffix);
            var penWidth = info.GetInt32(name + PenWidthSuffix);
            var dashStyle = info.GetValue<DashStyle>(name + PenDashStyleSuffix);
            return new Pen(penColor, penWidth) { DashStyle = dashStyle };
        }



        public static void AddBrush(this SerializationInfo info, string name, Brush brush)
        {
            var solidBrush = brush as SolidBrush;
            if (solidBrush != null)
            {
                info.AddSolidBrush(name, solidBrush);
                return;
            }

            var linearGradientBrush = brush as LinearGradientBrush;
            if (linearGradientBrush != null)
            {
                info.AddLinearGradientBrush(name, linearGradientBrush);
                return;
            }

            throw new ArgumentException("Brush type not supported.");
        }

        public static Brush GetBrush(this SerializationInfo info, string name)
        {
            string type = info.GetString(name + BrushTypeSuffix);

            if (type == SolidBrushType)
                return info.GetSolidBrush(name);

            if (type == LinearGradientBrushType)
                return info.GetLinearGradientBrush(name);

            throw new Exception("Brush not found.");
        }


        
        public static void AddSolidBrush(this SerializationInfo info, string name, SolidBrush brush)
        {
            info.AddValue(name + BrushTypeSuffix, SolidBrushType);
            info.AddColor(name + SolidBrushColorSuffix, brush.Color);
        }

        public static SolidBrush GetSolidBrush(this SerializationInfo info, string name)
        {
            var brushColor = info.GetColor(name + SolidBrushColorSuffix);
            return new SolidBrush(brushColor);
        }


        public static void AddLinearGradientBrush(this SerializationInfo info, string name, LinearGradientBrush brush)
        {
            info.AddValue(name + BrushTypeSuffix, LinearGradientBrushType);
            info.AddRectangle(name + LinearGradientRectangleSuffix, brush.Rectangle);
            info.AddColor(name + LinearGradientFirstColorSuffix, brush.LinearColors[0]);
            info.AddColor(name + LinearGradientSecondColorSuffix, brush.LinearColors[1]);
        }

        public static LinearGradientBrush GetLinearGradientBrush(this SerializationInfo info, string name)
        {
            var rectangle = info.GetRectangle(name + LinearGradientRectangleSuffix);
            var firstColor = info.GetColor(name + LinearGradientFirstColorSuffix);
            var secondColor = info.GetColor(name + LinearGradientSecondColorSuffix);
            return new LinearGradientBrush(new Point(rectangle.X, rectangle.Y),
                                           new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height),
                                           firstColor, secondColor);
        }



        public static void AddRectangle(this SerializationInfo info, string name, RectangleF rectangle)
        {
            info.AddValue(name + RectangleXSuffix, rectangle.X);
            info.AddValue(name + RectangleYSuffix, rectangle.Y);
            info.AddValue(name + RectangleWidthSuffix, rectangle.Width);
            info.AddValue(name + RectangleHeightSuffix, rectangle.Height);
        }

        public static Rectangle GetRectangle(this SerializationInfo info, string name)
        {
            var x = info.GetInt32(name + RectangleXSuffix);
            var y = info.GetInt32(name + RectangleYSuffix);
            var width = info.GetInt32(name + RectangleWidthSuffix);
            var height = info.GetInt32(name + RectangleHeightSuffix);
            return new Rectangle(x, y, width, height);
        }
    }
}