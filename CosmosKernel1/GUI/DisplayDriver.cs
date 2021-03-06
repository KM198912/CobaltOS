﻿using CobaltOS.Font;
using System;
using System.Drawing;

namespace CobaltOS.GUI
{
    class DisplayDriver
    {
        private static Boolean newGraphics;

        public static void init(Boolean graphics)
        {
            newGraphics = graphics;
        }

        public static void initScreen()
        {
            if (newGraphics) VMDisplayDriver.initScreen();
            else CanvasDisplayDriver.initScreen();
        }

        public static void setPixel(int x, int y, Color c)
        {
            if (newGraphics) VMDisplayDriver.setPixel(x, y, c);
            else CanvasDisplayDriver.setPixel(x, y, c);
        }

        public static void changeRes(int x, int y)
        {
            if (newGraphics) VMDisplayDriver.changeRes(x, y);
            else CanvasDisplayDriver.changeRes(x, y);
        }

        public static int addText(int x, int y, Color c, String s, Boolean newFont)
        {
            if (newFont)
            {
                return FontDrawer.WriteText(s, x, y + 8, c);
            } else
            {
                if (newGraphics) return VMDisplayDriver.addText(x, y, c, s);
                else return CanvasDisplayDriver.addText(x, y, c, s);
            }
        }

        public static int typeChar(int x, int y, Color c, Char s, Boolean newFont)
        {
            if (newFont)
            {
                return FontDrawer.WriteText(s.ToString(), x, y, c);
            } else
            {
                if (newGraphics) return VMDisplayDriver.typeChar(x, y, c, s);
                else return CanvasDisplayDriver.typeChar(x, y, c, s);
            }
        }

        public static void setFullBuffer(Color c)
        {
            if (newGraphics) VMDisplayDriver.setFullBuffer(c);
            else CanvasDisplayDriver.setFullBuffer(c);
        }

        public static void addMouse(int x, int y)
        {
            if (newGraphics) VMDisplayDriver.addMouse(x, y);
            else CanvasDisplayDriver.addMouse(x, y);
        }

        public static void drawScreen()
        {
            if (newGraphics) VMDisplayDriver.drawScreen();
            else CanvasDisplayDriver.drawScreen();
        }

        public static void addRectangle(int x, int y, int endX, int endY, Color c)
        {
            if (newGraphics) VMDisplayDriver.addRectangle(x, y, endX, endY, c);
            else CanvasDisplayDriver.addRectangle(x, y, endX, endY, c);
        }

        public static void addFilledRectangle(int x, int y, int w, int h, Color c)
        {
            if (newGraphics) VMDisplayDriver.addFilledRectangle(x, y, w, h, c);
            else CanvasDisplayDriver.addFilledRectangle(x, y, w, h, c);
        }

        public static void addImage(String path, int x, int y)
        {
            if (newGraphics) VMDisplayDriver.DrawPictureFromFile(path, x, y);
            else CanvasDisplayDriver.DrawPictureFromFile(path, x, y);
        }

        public static void exitGUI()
        {
            if (Kernel.graphicsMode)
            {
                if (newGraphics) VMDisplayDriver.exitGUI();
                else CanvasDisplayDriver.exitGUI();
            }
        }


        // ---------------- EXPERIMENTAL SECTION -------------------------------

        private static double rainbowR, rainbowG, rainbowB, rainbowIndex = 0;
        private static double freq = 0.05;

        public static void addFilledRectangleR(int x, int y, int w, int h)
        {
            DisplayDriver.addFilledRectangle(x, y, w, h, Color.FromArgb((int)rainbowR, (int)rainbowG, (int)rainbowB));
        }
        public static void addRectangleR(int x, int y, int w, int h)
        {
            DisplayDriver.addRectangle(x, y, x + w, y + h, Color.FromArgb((int)rainbowR, (int)rainbowG, (int)rainbowB));
        }

        public static void tickRainbow()
        {
            if (rainbowIndex == 129) rainbowIndex = 0;

            rainbowR = Math.Sin(freq * rainbowIndex + 0) * 127 + 128;
            rainbowG = Math.Sin(freq * rainbowIndex + 2) * 127 + 128;
            rainbowB = Math.Sin(freq * rainbowIndex + 4) * 127 + 128;

            rainbowIndex++;
        }


        // -----------------------------------------------------------------------  
    }
}
