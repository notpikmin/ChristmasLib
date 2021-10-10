using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;

namespace ChristmasLib.UI
{
    public  class ChristmasUI
    {
        public bool UIOpen = false;

        public  void Setup()
        {
            ImGui.CreateContext();
            ImGuiIOPtr io = ImGui.GetIO();
            ImGui.StyleColorsDark();

        }
        
        public void UILoop()
        {
            if (UIOpen)
            {
                
               
                ImGui.NewFrame();

                

                ImGui.Begin("FUCK");
                ImGui.Button("FUCCKAKCS");
                ImGui.End();

                ImGui.Render();

            }
        }
    }
}
