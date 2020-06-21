using System;
using System.Collections.Generic;
using System.Threading;

namespace PongPongUI
{
    class Program
    {
        #region particle list
        public static List<Particle> Particles { get; private set; } = new List<Particle>();
        #endregion
        #region main function
        static void Main(string[] args)
        {
            //disable cursor in console window
            Console.CursorVisible = false;
            while (true)
            {
                Thread.Sleep(40);
                CreateParticle();
                DrawParticle();
                ClearParticle();
            }
        }
        #endregion
        #region creates specified number of particles
        private static void CreateParticle(int count = 1)
        {

            for (int i = 0; i < count; i++)
            {
                Particles.Add(new Particle
                {
                    X = new Random().Next(Console.WindowWidth),
                    Y = new Random().Next(Console.WindowHeight),
                    Color = RandomColor()[new Random().Next(RandomColor().Count)]
                });
            }
        }
        #endregion
        #region generates random colors
        private static List<ConsoleColor> RandomColor()
        {
            List<ConsoleColor> Colors = new List<ConsoleColor>();
            Colors.Add(ConsoleColor.Red);
            Colors.Add(ConsoleColor.Green);
            Colors.Add(ConsoleColor.Yellow);
            Colors.Add(ConsoleColor.Magenta);
            Colors.Add(ConsoleColor.Blue);
            Colors.Add(ConsoleColor.Cyan);
            return Colors;
        }
        #endregion
        #region draws particle
        private static void DrawParticle()
        {
            foreach (var particle in Particles)
            {
                Console.SetCursorPosition(particle.X, particle.Y);
                Console.ForegroundColor = particle.Color;
                Console.Write(".");
            }
        }
        #endregion
        #region clear particles
        private static void ClearParticle()
        {
            Particles = new List<Particle>();
        }
        #endregion
    }
}
