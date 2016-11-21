using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            
        }

        String task;
        int taskNumber = 0;
        int location = 1;
        int indexId = 1;

        private void btnHelp_Click(object sender, EventArgs e)
        {
          //  AddNewPanel();
        }

        //private void AddNewPanel()
        //{
        //    taskNumber++;
        //    label3.Text = taskNumber.ToString();

        //    task = richTextBox1.Text;
        //    label2.Text = task;

        //    panel1.Visible = true;
        //    richTextBox1.Text = null;
        //    checkBox1.Visible = true;

        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Please, Write a task! ");
            }
            else
            {
                AddNewTaskContents();
                richTextBox1.Text = null;
            }
    
        }

        

        private void AddNewTaskContents()
        {
            //
            //Create a Label counter inside the panel
            //
            Label newLabel = new Label();
            newLabel.Name = "labelCounter" + indexId;
            newLabel.AutoSize = true;
            newLabel.Location = new System.Drawing.Point(17, 14);
            newLabel.Size = new System.Drawing.Size(0, 13);

            taskNumber++;
            newLabel.Text = taskNumber.ToString();

            //
            //Create a checkBox inside the panel
            //
            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Name = "CheckBox" + indexId;
            newCheckBox.AutoSize = true;
            newCheckBox.Location = new System.Drawing.Point(76, 14);
            newCheckBox.Size = new System.Drawing.Size(15, 14);
            newCheckBox.TabIndex = 5;
            newCheckBox.UseVisualStyleBackColor = true;
            newCheckBox.Visible = true;
            newCheckBox.CheckedChanged += new EventHandler(newcheckBox_CheckedChanged);

            //
            //Create a Label task inside the panel
            //
            Label newLabelTask = new Label();
            newLabelTask.Name = "LabelTask" + indexId;
            newLabelTask.AutoSize = true;
            newLabelTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newLabelTask.Location = new System.Drawing.Point(114, 12);
            newLabelTask.Size = new System.Drawing.Size(0, 16);
            newLabelTask.Visible = true;
            newLabelTask.TabIndex = 4;

            task = richTextBox1.Text;
            newLabelTask.Text = task;


            //
            //Create a RichText task inside the panel
            //
            //RichTextBox newRichText = new RichTextBox();
            //newRichText.Name = "RichText" + indexId;
            //newRichText.Location = new System.Drawing.Point(117, 3);
            //newRichText.Size = new System.Drawing.Size(380, 52);
            //newRichText.TabIndex = 8;
            //newRichText.Visible = true;

            //task = richTextBox1.Text;
            //newRichText.Text = task;

            //
            //Create a Remove button inside the panel
            //
            Button btnRemove = new Button();
            btnRemove.Name = "Remove" + indexId;
            btnRemove.Text = "Remove"; //+ indexId.ToString();
            btnRemove.Size = new System.Drawing.Size(75, 26);
            btnRemove.Location = new System.Drawing.Point(546, 18);
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Visible = true ;
            btnRemove.Click += new EventHandler(btnRemove_Click);

            //
            //Create a Panel for all conponents 
            //
            Panel newPanel = new Panel();
            newPanel.Name = "Panel" + indexId;
            newPanel.Text = "newPanel" + indexId.ToString();
            newPanel.Location = new System.Drawing.Point(12, 58 + (60 * location));
            newPanel.Size = new System.Drawing.Size(639, 58);
            newPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;

            //
            //Adding all the components in the form when the 'ADD Task' button gets pressed
            //
            newPanel.Controls.Add(newLabel);
            newPanel.Controls.Add(newCheckBox);
            newPanel.Controls.Add(newLabelTask);
            //newPanel.Controls.Add(newRichText);
            newPanel.Controls.Add(btnRemove);

            Controls.Add(newPanel);

            indexId++;
            location++;
        }

        //
        //The Remove button fecture is working as expected
        //

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("working 0");
            
           string senderIndex = ((Button)sender).Name.Remove(0,6); //'.Name.Remove(0, 6)' removes the button's name from 0 to 6th character

           Controls.RemoveByKey("Panel" + senderIndex);

            //MessageBox.Show("" + senderIndex);

            indexId--;
            location--;
            taskNumber--;

            //Make sure the location is '1' can not be '0'
            //taskNumber must start from '1' e can't be negative number  
            //indexId must start from '1' e can't be negative number
            if (location < 1 || taskNumber < 1 || indexId < 1)
            {
                taskNumber = 0;
                location = 1;
                indexId = 1;
            }

            MessageBox.Show("index" + indexId);
        }

        //
        //The checkBox fecture is still under developmenting, not working as expected
        //
        private void newcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Name = ((CheckBox)sender).Name;
            // MessageBox.Show("working 1");

            //  int senderIndex = Convert.ToInt32(((CheckBox)sender).Name.Remove(0, 8));

            string senderIndex = ((CheckBox)sender).Name;

           
            MessageBox.Show(senderIndex);

            newCheckBox.Enabled = true;

        }

        //END

        //
        //The bellow code is just a testing for the feacture that is being implemented
        //


        //private void btnRemove_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    checkBox1.Checked = false;
        //    checkBox1.Enabled = true;
        //    label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    //newCheckBox.Enabled = false;
        //}

    }
}
