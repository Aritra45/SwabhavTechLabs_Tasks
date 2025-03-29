using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderMethodDesignPattern.Repository;

namespace BuilderMethodDesignPattern.Model
{
    internal class CellPhone : I_Configaration
    {
        public string OS { get; set; }
        public int Battery { get; set; }
        public int Camera { get; set; }
        public double ScreenSize { get; set; }
        public string Processor { get; set; }

        public void SetBattery(int battery)
        {
            Battery = battery;
        }

        public void SetCamera(int camera)
        {
            Camera = camera;
        }

        public void SetScreenSize(double screenSize)
        {
            ScreenSize = screenSize;
        }

        public void SetOS(string os)
        {
            OS = os;
        }

        public void SetProcessor(string processor)
        {
            Processor = processor;
        }

        public override string ToString()
        {
            return $"Processor: {Processor}, OS: {OS}, ScreenSize: {ScreenSize}, Camera: {Camera}, Battery: {Battery}";
        }
    }
}
