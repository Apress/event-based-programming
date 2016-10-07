using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.OrderEntry
{
	/// <summary>
	/// Summary description for WorkerOrderEntry.
	/// </summary>
  public class WorkerOrderEntry : System.Windows.Forms.UserControl
  {
    #region Controls
    public System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TreeView treeViewOptions;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboBoxStyle;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBoxModel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button buttonSubmit;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox comboBoxColor;
    private System.Windows.Forms.Label labelTotalPrice;
	  private System.ComponentModel.Container components = null;
    #endregion

	  public WorkerOrderEntry()
	  {
		  // This call is required by the Windows.Forms Form Designer.
		  InitializeComponent();
	  }

	  /// <summary> 
	  /// Clean up any resources being used.
	  /// </summary>
	  protected override void Dispose( bool disposing )
	  {
		  if( disposing )
		  {
			  if(components != null)
			  {
				  components.Dispose();
			  }
		  }
		  base.Dispose( disposing );
	  }

	  #region Component Designer generated code
	  /// <summary> 
	  /// Required method for Designer support - do not modify 
	  /// the contents of this method with the code editor.
	  /// </summary>
	  private void InitializeComponent()
	  {
      this.panelMain = new System.Windows.Forms.Panel();
      this.comboBoxColor = new System.Windows.Forms.ComboBox();
      this.labelTotalPrice = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.buttonSubmit = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.treeViewOptions = new System.Windows.Forms.TreeView();
      this.label3 = new System.Windows.Forms.Label();
      this.comboBoxStyle = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBoxModel = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panelMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelMain
      // 
      this.panelMain.Controls.Add(this.comboBoxColor);
      this.panelMain.Controls.Add(this.labelTotalPrice);
      this.panelMain.Controls.Add(this.label5);
      this.panelMain.Controls.Add(this.buttonSubmit);
      this.panelMain.Controls.Add(this.label4);
      this.panelMain.Controls.Add(this.treeViewOptions);
      this.panelMain.Controls.Add(this.label3);
      this.panelMain.Controls.Add(this.comboBoxStyle);
      this.panelMain.Controls.Add(this.label2);
      this.panelMain.Controls.Add(this.comboBoxModel);
      this.panelMain.Controls.Add(this.label1);
      this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelMain.Location = new System.Drawing.Point(0, 0);
      this.panelMain.Name = "panelMain";
      this.panelMain.Size = new System.Drawing.Size(379, 338);
      this.panelMain.TabIndex = 0;
      // 
      // comboBoxColor
      // 
      this.comboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxColor.Location = new System.Drawing.Point(255, 30);
      this.comboBoxColor.Name = "comboBoxColor";
      this.comboBoxColor.Size = new System.Drawing.Size(97, 24);
      this.comboBoxColor.TabIndex = 5;
      // 
      // labelTotalPrice
      // 
      this.labelTotalPrice.AutoSize = true;
      this.labelTotalPrice.Location = new System.Drawing.Point(165, 268);
      this.labelTotalPrice.Name = "labelTotalPrice";
      this.labelTotalPrice.Size = new System.Drawing.Size(23, 18);
      this.labelTotalPrice.TabIndex = 9;
      this.labelTotalPrice.Text = "$ 0";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(31, 268);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(137, 18);
      this.label5.TabIndex = 8;
      this.label5.Text = "Total Price of Options:";
      // 
      // buttonSubmit
      // 
      this.buttonSubmit.Location = new System.Drawing.Point(149, 299);
      this.buttonSubmit.Name = "buttonSubmit";
      this.buttonSubmit.Size = new System.Drawing.Size(102, 23);
      this.buttonSubmit.TabIndex = 10;
      this.buttonSubmit.Text = "Submit Order";
      this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(29, 59);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 18);
      this.label4.TabIndex = 6;
      this.label4.Text = "Options:";
      // 
      // treeViewOptions
      // 
      this.treeViewOptions.CheckBoxes = true;
      this.treeViewOptions.ImageIndex = -1;
      this.treeViewOptions.Location = new System.Drawing.Point(26, 78);
      this.treeViewOptions.Name = "treeViewOptions";
      this.treeViewOptions.SelectedImageIndex = -1;
      this.treeViewOptions.Size = new System.Drawing.Size(327, 180);
      this.treeViewOptions.TabIndex = 7;
      this.treeViewOptions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewOptions_AfterCheck);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(259, 10);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 18);
      this.label3.TabIndex = 4;
      this.label3.Text = "Color:";
      // 
      // comboBoxStyle
      // 
      this.comboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxStyle.Location = new System.Drawing.Point(137, 30);
      this.comboBoxStyle.Name = "comboBoxStyle";
      this.comboBoxStyle.Size = new System.Drawing.Size(97, 24);
      this.comboBoxStyle.TabIndex = 3;
      this.comboBoxStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxStyle_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(142, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 18);
      this.label2.TabIndex = 2;
      this.label2.Text = "Style:";
      // 
      // comboBoxModel
      // 
      this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxModel.Location = new System.Drawing.Point(22, 29);
      this.comboBoxModel.Name = "comboBoxModel";
      this.comboBoxModel.Size = new System.Drawing.Size(97, 24);
      this.comboBoxModel.TabIndex = 1;
      this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxModel_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(21, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Model:";
      // 
      // WorkerOrderEntry
      // 
      this.Controls.Add(this.panelMain);
      this.Name = "WorkerOrderEntry";
      this.Size = new System.Drawing.Size(379, 338);
      this.panelMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }
	  #endregion

    private void comboBoxModel_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      comboBoxStyle.Items.Clear();
      string model = comboBoxModel.Text;
      string[] styles = FireGetStyles(model);
      if (styles == null) return;
      if (styles.Length == 0) return;
      comboBoxStyle.Items.AddRange(styles);
      comboBoxStyle.SelectedIndex = 0;
    }

    private void comboBoxStyle_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      treeViewOptions.Nodes.Clear();
      string model = comboBoxModel.Text;
      string style = comboBoxStyle.Text;
      ArrayList options = FireGetOptions(model, style);
      if (options != null)
        PopulateOptions(options);

      Color[] colors = FireGetColors(model, style);
      comboBoxColor.Items.Clear();
      if (colors == null) return;
      if (colors.Length == 0) return;
      foreach (Color color in colors)
        comboBoxColor.Items.Add(color.ToKnownColor().ToString());
      comboBoxColor.SelectedIndex = 0;
    }

    // each entry in theOptions is a PricedItem array. In each array, the
    // first element is the option category, the remaining elements
    // are the options for the given category
    void PopulateOptions(ArrayList theOptions)
    {
      if (theOptions == null) return;

      foreach (PricedItem[] options in theOptions)
        PopulateOption(options);

      treeViewOptions.ExpandAll();
    }
    
    // first item is category, remainders are options
    void PopulateOption(PricedItem[] theOptions)
    {
      if (theOptions.Length == 0) return;

      PricedItem category = theOptions[0];
      TreeNode categoryNode = new TreeNode(category.Name);
      categoryNode.Tag = category;
      treeViewOptions.Nodes.Add(categoryNode);

      for (int i = 1; i < theOptions.Length; i++)
      {
        PricedItem option = theOptions[i];
        TreeNode node = new TreeNode(option.Name);
        node.Tag = option;
        categoryNode.Nodes.Add(node);
      }
    }

    void PopulateOption(TreeNode theNode, PricedItem[] theOptions)
    {
      foreach (PricedItem option in theOptions)
      {
        TreeNode node = new TreeNode(option.Name);
        theNode.Nodes.Add(node);
      }
    }

    public void PopulateModels(string[] theModels)
    {
      comboBoxModel.Items.Clear();
      if (theModels == null) return;
      if (theModels.Length == 0) return;
      comboBoxModel.Items.AddRange(theModels);
      comboBoxModel.SelectedIndex = 0;
    }

    private void treeViewOptions_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
    {
      TreeNode node = e.Node;
      if (node == null) return;

      if (IsCategoryNode(node))
      {
        // check or uncheck all the child options
        foreach (TreeNode childNode in node.Nodes)
          childNode.Checked = node.Checked;
      }

      else
        // must be an Options node
        UpdateOptionsCost();
    }

    bool IsCategoryNode(TreeNode theNode)
    {
      // category nodes are at the root level
      return theNode.Parent == null;
    }

    void UpdateOptionsCost()
    {
      ArrayList optionsSelected = new ArrayList();

      // get a list of all the selected options
      foreach (TreeNode categoryNode in treeViewOptions.Nodes)
        foreach (TreeNode optionNode in categoryNode.Nodes)
          if (optionNode.Checked)
            optionsSelected.Add(optionNode.Tag);

      // get total cost of options and show result
      PricedItem[] options = optionsSelected.ToArray(typeof(PricedItem)) as PricedItem[];
      decimal totalPrice = FireComputeCostOfOptions(options);
      labelTotalPrice.Text = totalPrice.ToString("C");  // display as a currency
    }

    private void buttonSubmit_Click(object sender, System.EventArgs e)
    {
      ArrayList options = new ArrayList();
      foreach (TreeNode categoryNode in treeViewOptions.Nodes)
        foreach (TreeNode optionNode in categoryNode.Nodes)
          if (optionNode.Checked)
            options.Add(optionNode.Tag);

      PricedItem[] items = options.ToArray(typeof(PricedItem)) as PricedItem[];
      Color color = Color.FromName(comboBoxColor.Text);
      FireSubmitOrder(comboBoxModel.Text, comboBoxStyle.Text, color, items);
    }

    public delegate string[] GetStylesHandler(string theModel);
    public event GetStylesHandler OnGetStyles;
    string[] FireGetStyles(string theModel)
    {
      if (OnGetStyles == null)
        return null;
      return OnGetStyles(theModel);
    }

    public delegate Color[] GetColorsHandler(string theModel, string theStyle);
    public event GetColorsHandler OnGetColors;
    Color[] FireGetColors(string theModel, string theStyle)
    {
      if (OnGetColors == null)
        return null;
      return OnGetColors(theModel, theStyle);
    }

    public delegate ArrayList GetOptionsHandler(string theModel, string theStyle);
    public event GetOptionsHandler OnGetOptions;
    ArrayList FireGetOptions(string theModel, string theStyle)
    {
      if (OnGetOptions == null)
        return null;
      return OnGetOptions(theModel, theStyle);
    }

    public delegate void SubmitOrderHandler(string theModel, string theStyle, Color theColor, PricedItem[] theOptions);
    public event SubmitOrderHandler OnSubmitOrder;
    void FireSubmitOrder(string theModel, string theStyle, Color theColor, PricedItem[] theOptions)
    {
      if (OnSubmitOrder != null)
        OnSubmitOrder(theModel, theStyle, theColor, theOptions);
    }

    public delegate decimal ComputeCostOfOptionsHandler(PricedItem[] theOptionsSelected);
    public event ComputeCostOfOptionsHandler OnComputeCostOfOptions;
    decimal FireComputeCostOfOptions(PricedItem[] theOptionsSelected)
    {
      if (OnComputeCostOfOptions == null)
        return 0;
      return OnComputeCostOfOptions(theOptionsSelected);
    }
  }
}
