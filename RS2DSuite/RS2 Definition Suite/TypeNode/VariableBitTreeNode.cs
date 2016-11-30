using RS2_Definition_Suite.RS319;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Definition_Suite.TypeNode
{
    public class VariableBitTreeNode : System.Windows.Forms.TreeNode
    {
        private readonly VariableBit param;

        public VariableBitTreeNode(string name, VariableBit param)
        {
            base.Text = name;
            this.param = param;
        }

        public VariableBit AssignedVariableParameter
        {
            get
            {
                return this.param;
            }
        }
    }
}
