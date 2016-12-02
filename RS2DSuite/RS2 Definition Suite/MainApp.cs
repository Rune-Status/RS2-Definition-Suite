using CEBL;
using RS2_Definition_Suite.RS319;
using RS2_Definition_Suite.TypeNode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS2_Definition_Suite
{
    public partial class MainApp : Form
    {

        public enum REVISION
        {
            RS319, RS377
        }

        public static REVISION selectedRevision;
        private CacheUnpacker unpacker;
        private StreamLoader spriteStream;
        private CEBL.Stream interfaceStream;
        private StreamLoader titleStreamLoader;
        private TextDrawingArea smallText;
        private TextDrawingArea aTextDrawingArea_1271;
        private TextDrawingArea chatTextDrawingArea;
        private TextDrawingArea[] aclass30_sub2_sub1_sub4s;
        private bool cacheLoaded;
        private StreamLoader configStreamLoader;
        private StreamLoader interfaceStreamLoader;
        private StreamLoader textureStreamLoader;
        private StreamLoader chattSystemStreamLoader;
        private StreamLoader soundStreamLoader;

        public MainApp()
        {
            InitializeComponent();
        }

        private void cacheSelectorBox_EnabledChanged(object sender, EventArgs e)
        {
            if(cacheSelectorBox.Enabled)
            {
                cacheSelectorBox.SelectedIndex = 0;
                MainApp.selectedRevision = REVISION.RS319;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            cacheSelectorBox.Enabled = true;
        }

        private void cacheSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRevision = cacheSelectorBox.SelectedIndex == 0 ? REVISION.RS319 : REVISION.RS377;
            loadedLabel2.Text = selectedRevision.ToString();
        }

        private void openCache_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.unpacker = new CacheUnpacker();
                if (CEBL.Main.cache != null)
                {
                    CEBL.Main.cache.Close();
                }
                try
                {
                    this.unpacker.LoadCache(dialog.SelectedPath);
                    this.unpacker.SetDecompressors();
                }
                catch (FileNotFoundException)
                {
                    if (CEBL.Main.cache != null)
                    {
                        CEBL.Main.cache.Close();
                    }
                    MessageBox.Show("Unable to load cache. Missing files.", "Error Loading Cache");
                    //this.reset();
                    cacheLoaded = false;
                    loadedLabel1.Text = "Error loading cache: ";
                    return;
                }
                catch (IOException)
                {
                    if (CEBL.Main.cache != null)
                    {
                        CEBL.Main.cache.Close();
                    }
                    MessageBox.Show("Unable to load cache. Most likely in use elsewhere.", "Error Loading Cache");
                    //this.reset();
                    cacheLoaded = false;
                    loadedLabel1.Text = "Error loading cache: ";
                    return;
                }
                this.finalizeCacheLoading();
                if (cacheLoaded)
                    loadedLabel1.Text = "Cache successfully loaded: ";
                else
                    loadedLabel1.Text = "Error loading cache: ";
            }
        }

        private void finalizeCacheLoading()
        {
            this.titleStreamLoader = this.unpacker.streamLoaderForName(1, "title screen", "title", this.unpacker.expectedCRCs[1], 0x19);
            this.smallText = new TextDrawingArea(false, "p11_full", this.titleStreamLoader);
            this.aTextDrawingArea_1271 = new TextDrawingArea(false, "p12_full", this.titleStreamLoader);
            this.chatTextDrawingArea = new TextDrawingArea(false, "b12_full", this.titleStreamLoader);
            TextDrawingArea area = new TextDrawingArea(true, "q8_full", this.titleStreamLoader);
            this.aclass30_sub2_sub1_sub4s = new TextDrawingArea[] { this.smallText, this.aTextDrawingArea_1271, this.chatTextDrawingArea, area };
            DrawingArea.initDrawingArea(0x1f6, 0x2fb, DrawingArea.getTransparentPixels(0x2fb, 0x1f6));
            configStreamLoader = this.unpacker.streamLoaderForName(2, "config", "config", this.unpacker.expectedCRCs[2], 30);
            interfaceStreamLoader = this.unpacker.streamLoaderForName(3, "interface", "interface", this.unpacker.expectedCRCs[3], 35);
            spriteStream = this.unpacker.streamLoaderForName(4, "2d graphics", "media", this.unpacker.expectedCRCs[4], 40);
            textureStreamLoader = this.unpacker.streamLoaderForName(6, "textures", "textures", this.unpacker.expectedCRCs[6], 45);
            chattSystemStreamLoader = this.unpacker.streamLoaderForName(7, "chat system", "wordenc", this.unpacker.expectedCRCs[7], 50);
            soundStreamLoader = this.unpacker.streamLoaderForName(8, "sound effects", "sounds", this.unpacker.expectedCRCs[8], 55);
            vlStreamLoader = this.unpacker.streamLoaderForName(5, "update list", "versionlist", this.unpacker.expectedCRCs[5], 60);
            this.interfaceStream = new CEBL.Stream(interfaceStreamLoader.getDataForName("data"));
            VariableParameter.init(configStreamLoader);
            VariableBit.init(configStreamLoader);
            //ItemDefinition.init(configStreamLoader);
            //ItemDefinition.pack("./");
            //RSInterface.globalTDAs = this.aclass30_sub2_sub1_sub4s;
            //RSInterface.unpack(this.interfaceStream, spriteStream, this);
            treeView1.Enabled = cacheLoaded = true;
        }

        private void loadedLabel1_Paint(object sender, PaintEventArgs e)
        {
        }

        public Credits creditsWindow;
        private StreamLoader vlStreamLoader;

        private void credits_Click(object sender, EventArgs e)
        {
            if (creditsWindow == null)
                creditsWindow = new Credits();
            creditsWindow.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Level == 1)
            {
                switch(e.Node.Index)
                {
                    case 7:
                        VariableParamaterToolShed shed = new VariableParamaterToolShed();
                        shed.Name = "varparamtoolshed";
                        shed.Dock = DockStyle.Fill;
                        for(int i = 0; i < VariableParameter.getCount(); i++)
                        {
                            VariableParameterTreeNode node = new VariableParameterTreeNode(i.ToString(), VariableParameter.parameters[i]);
                            shed.indexTreeView.Nodes.Add(node);
                        }
                        shed.indexTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(indexTreeView_NodeMouseClick);
                        shed.addParameter.Click += new System.EventHandler(addParameter_Click);
                        shed.removeParameter.Click += new System.EventHandler(removeParameter_Click);
                        shed.exportVarp.Click += new System.EventHandler(exportVarp_Click);
                        shed.addUpTo.Click += new System.EventHandler(addUpTo_Click);

                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(shed);
                        // Fill panel2 with Variable Parameter window.
                        break;

                    case 8:
                        VariableBitToolShed shed1 = new VariableBitToolShed();
                        shed1.Name = "varbittoolshed";
                        shed1.Dock = DockStyle.Fill;
                        for (int i = 0; i < VariableBit.getCount(); i++)
                        {
                            VariableBitTreeNode node = new VariableBitTreeNode(i.ToString(), VariableBit.cache[i]);
                            shed1.indexTreeView.Nodes.Add(node);
                        }
                        shed1.indexTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(indexTreeView1_NodeMouseClick);
                        shed1.addParameter.Click += new System.EventHandler(addBit_Click);
                        shed1.removeParameter.Click += new System.EventHandler(removeBit_Click);
                        shed1.exportVarp.Click += new System.EventHandler(exportVarBit_Click);
                        shed1.addUpTo.Click += new System.EventHandler(addUpTo1_Click);

                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(shed1);
                        break;
                    default:
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(selectParentText);
                        break;
                }
            }
            System.Console.WriteLine("Node name: " + e.Node.Text + ", index: " + e.Node.Index + ", Level: " + e.Node.Level);
        }

        public Control GetControlByName(string Name)
        {
            foreach (Control c in splitContainer1.Panel2.Controls)
                if (c.Name == Name)
                    return c;

            return null;
        }

        private void indexTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        { // 
            if (splitContainer1.Panel2.Controls.ContainsKey("varparamtoolshed"))
            {
                if (this.cacheLoaded)
                {
                    if (e.Node == null)
                    {
                        ((VariableParamaterToolShed) GetControlByName("varparamtoolshed")).propertyEditor.SelectedObject = null;
                    }
                    else
                    {
                        ((VariableParamaterToolShed) GetControlByName("varparamtoolshed")).propertyEditor.SelectedObject = ((VariableParameterTreeNode) e.Node).AssignedVariableParameter;
                    }
                }
            }
        }

        private void exportVarp_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save Variable Parameters",
                Filter = "Dat Files (*.DAT)|*.dat"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    VariableParameter.pack(new BinaryWriter(File.Create(dialog.FileName)));
                }
                catch (ExecutionEngineException exception)
                {
                    MessageBox.Show("Error saving. Backing up varp cache...\n\nLog:\n" + exception.Message, "Error Saving");
                }
            }


            //VariableParameter.pack(new FileStream("./varp.dat", FileMode.Create));
        }

        private void addParameter_Click(object sender, EventArgs e)
        {
            int newIndex = VariableParameter.parameters.Count;
            VariableParameter newParameter = new VariableParameter(0, 0, 0, 0, "", 0); // Creating a new blank variable parameter.
            VariableParameter.parameters.Add(newParameter);
            if (splitContainer1.Panel2.Controls.ContainsKey("varparamtoolshed"))
            {
                VariableParameterTreeNode node = new VariableParameterTreeNode(newIndex.ToString(), VariableParameter.parameters[newIndex]);
                ((VariableParamaterToolShed) GetControlByName("varparamtoolshed")).indexTreeView.Nodes.Add(node);
            }
        }

        private void addUpTo_Click(object sender, EventArgs e)
        {
            for (int newIndex = VariableParameter.parameters.Count; newIndex < ((VariableParamaterToolShed)GetControlByName("varparamtoolshed")).upTo.Value + 1; newIndex++)
            {
                VariableParameter newParameter = new VariableParameter(0, 0, 0, 0, "", 0); // Creating a new blank variable parameter.
                VariableParameter.parameters.Add(newParameter);
                if (splitContainer1.Panel2.Controls.ContainsKey("varparamtoolshed"))
                {
                    VariableParameterTreeNode node = new VariableParameterTreeNode(newIndex.ToString(), VariableParameter.parameters[newIndex]);
                    ((VariableParamaterToolShed)GetControlByName("varparamtoolshed")).indexTreeView.Nodes.Add(node);
                }
            }
        }

        private void removeParameter_Click(object sender, EventArgs e)
        {
            int lastIndex = VariableParameter.parameters.Count - 1;
            VariableParameter.parameters.RemoveAt(lastIndex);
            if (splitContainer1.Panel2.Controls.ContainsKey("varparamtoolshed"))
            {
                ((VariableParamaterToolShed) GetControlByName("varparamtoolshed")).indexTreeView.Nodes.RemoveAt(lastIndex);
            }
        }





        private void indexTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        { // 
            if (splitContainer1.Panel2.Controls.ContainsKey("varbittoolshed"))
            {
                if (this.cacheLoaded)
                {
                    if (e.Node == null)
                    {
                        ((VariableBitToolShed)GetControlByName("varbittoolshed")).propertyEditor.SelectedObject = null;
                    }
                    else
                    {
                        ((VariableBitToolShed)GetControlByName("varbittoolshed")).propertyEditor.SelectedObject = ((VariableBitTreeNode)e.Node).AssignedVariableParameter;
                    }
                }
            }
        }

        private void exportVarBit_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save Variable Bits",
                Filter = "Dat Files (*.DAT)|*.dat"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    VariableBit.pack(new BinaryWriter(File.Create(dialog.FileName)));
                }
                catch (ExecutionEngineException exception)
                {
                    MessageBox.Show("Error saving. Backing up varbit cache...\n\nLog:\n" + exception.Message, "Error Saving");
                }
            }


            //VariableParameter.pack(new FileStream("./varp.dat", FileMode.Create));
        }

        private void addBit_Click(object sender, EventArgs e)
        {
            int newIndex = VariableBit.cache.Count;
            VariableBit newParameter = new VariableBit(newIndex, 0, 0, 0, "", 0, false); // Creating a new blank variable parameter.
            VariableBit.cache.Add(newParameter);
            if (splitContainer1.Panel2.Controls.ContainsKey("varbittoolshed"))
            {
                VariableBitTreeNode node = new VariableBitTreeNode(newIndex.ToString(), VariableBit.cache[newIndex]);
                ((VariableBitToolShed)GetControlByName("varbittoolshed")).indexTreeView.Nodes.Add(node);
            }
        }

        private void addUpTo1_Click(object sender, EventArgs e)
        {
            for (int newIndex = VariableBit.cache.Count; newIndex < ((VariableBitToolShed)GetControlByName("varbittoolshed")).upTo.Value + 1; newIndex++)
            {
                VariableBit newParameter = new VariableBit(newIndex, 0, 0, 0, "", 0, false); // Creating a new blank variable parameter.
                VariableBit.cache.Add(newParameter);
                if (splitContainer1.Panel2.Controls.ContainsKey("varbittoolshed"))
                {
                    VariableBitTreeNode node = new VariableBitTreeNode(newIndex.ToString(), VariableBit.cache[newIndex]);
                    ((VariableBitToolShed)GetControlByName("varbittoolshed")).indexTreeView.Nodes.Add(node);
                }
            }
        }

        private void removeBit_Click(object sender, EventArgs e)
        {
            int lastIndex = VariableBit.cache.Count - 1;
            VariableBit.cache.RemoveAt(lastIndex);
            if (splitContainer1.Panel2.Controls.ContainsKey("varbittoolshed"))
            {
                ((VariableBitToolShed) GetControlByName("varbittoolshed")).indexTreeView.Nodes.RemoveAt(lastIndex);
            }
        }


        private enum EditableConfig
        {
            VARPARAMETER
        }

        /*private void populateTreeList(TreeView view, EditableConfig config)
        {
            this.tvLayers.Nodes.Clear();
            bool flag = false;
            if (node == null)
            {
                node = new InterfaceTreeNode("Interface " + this.selectedInterfaceID);
                node.AssignedInterface = parent;
                flag = true;
            }
            if (parent.children != null)
            {
                for (int i = 0; i < parent.children.Length; i++)
                {
                    if (parent.children[i] != -1)
                    {
                        RSInterface interface2 = RSInterface.interfaceCache[parent.children[i]];
                        if (interface2.children == null)
                        {
                            InterfaceTreeNode node2 = new InterfaceTreeNode(this.getInterfaceName(interface2) + " - " + interface2.id)
                            {
                                AssignedInterface = interface2
                            };
                            node.Nodes.Add(node2);
                        }
                        else
                        {
                            InterfaceTreeNode node3 = new InterfaceTreeNode("Layer " + interface2.id)
                            {
                                AssignedInterface = interface2
                            };
                            node.Nodes.Add(node3);
                            this.populateTreeList(node3, interface2);
                        }
                    }
                }
            }
            if (flag)
            {
                this.tvLayers.Nodes.Add(node);
            }
        }*/
    }
}
