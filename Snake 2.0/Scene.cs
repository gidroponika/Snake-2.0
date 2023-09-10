using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal abstract class Scene
    {
        protected bool isActive;
        protected Border border;

        protected Scene(Border border)
        {
            this.border = border;
        }

        public abstract void Update();

        public abstract void Draw();
    }
}
