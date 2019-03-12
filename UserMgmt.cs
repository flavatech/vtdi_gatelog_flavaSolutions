﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTDI_Gate_Log1_flavaSolutions
{
    public partial class UserMgmt : Form
    {
        public UserMgmt()
        {
            InitializeComponent();
        }

        private void UsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gDataSetForAll);

        }

        private void UserMgmt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gDataSetForAll.Gender' table. You can move, or remove it, as needed.
            this.genderTableAdapter.Fill(this.gDataSetForAll.Gender);
            // TODO: This line of code loads data into the 'gDataSetForAll.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.gDataSetForAll.Users);
            //Start the timer for the status Display
            timer1.Start();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gDataSetForAll);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            Clear();
            this.usersBindingSource.AddNew();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.usersBindingSource.RemoveCurrent();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            count = usersBindingSource.Count;
            lblStatus.Text = "There are "+count.ToString() +" rows in your Database";

        }

        //Create a Global Variable For Count

        int count = 0;

        //Create a Global method for Clear
        private void Clear()
        {

            //Use Var to  enable use of user friendly names in clear command below.
            var Firstname = tbFirstName;
            var Lastname = tbLastName;
            var Email = tbEmail;
            var Username = tbUsername;
            var Password = tbPassword;
            var Gender = cbGender;


            Firstname.Clear();
            Lastname.Clear();
            Email.Clear();
            Username.Clear();
            Password.Clear();
            Gender.Text = "";
            Firstname.Focus();
        }

        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            usersBindingSource.MoveNext();
        }

        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            usersBindingSource.MovePrevious();
        }

        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            usersBindingSource.MoveFirst();
        }

        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            usersBindingSource.MoveLast();
        }

        private void NameToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.usersTableAdapter.Name(this.gDataSetForAll.Users, firstNameToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }

}
