using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEngine
{
    public interface Logic
    {
        void init();

        void input();

        void update(float interval, MouseInput mouseInput);

        void render();

        void cleanup();
    }
}
