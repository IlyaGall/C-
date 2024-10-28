using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalicitFinalProject.LineSupot
{
    /// <summary>
    /// линия поддержки
    /// </summary>
    public class LinePoint
    {
        /// <summary>
        /// координата Y
        /// </summary>
        public double CoordinateY { get; set; }
        /// <summary>
        /// координата x(double)
        /// </summary>
        public double CoordinateX { get; set; }
        /// <summary>
        /// координата x(время)
        /// </summary>
        public DateTime CoordinateXTime { get; set; }

        /// <summary>
        /// id точки поддержки из общего массива точек
        /// </summary>
        public int IdPoint { get; set; }

        /// <summary>
        /// тип линии поддержка: 1 , сопротивления: 0 
        /// </summary>
        public int TypeLine { get; set; }

        public LinePoint(double coordinateY, DateTime coordinateXTime, int idPoint, int typeLine)
        {
            CoordinateY = coordinateY;
            CoordinateXTime = coordinateXTime;
            IdPoint = idPoint;
            TypeLine = typeLine;
        }
        public LinePoint(double coordinateY, double coordinateX, int idPoint, int typeLine)
        {
            CoordinateY = coordinateY;
            CoordinateX = coordinateX;
            IdPoint = idPoint;
            TypeLine = typeLine;

        }

    }
}
