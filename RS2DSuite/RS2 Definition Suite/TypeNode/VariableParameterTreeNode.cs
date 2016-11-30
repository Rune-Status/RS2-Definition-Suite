using RS2_Definition_Suite.RS319;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Definition_Suite.TypeNode
{
    public class VariableParameterTreeNode : System.Windows.Forms.TreeNode
    {
        private readonly VariableParameter param;

        public VariableParameterTreeNode(string name, VariableParameter param)
        {
            base.Text = name;
            this.param = param;
        }

        public VariableParameter AssignedVariableParameter
        {
            get
            {
                return this.param;
            }
        }
    }
}
