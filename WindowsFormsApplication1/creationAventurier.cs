﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JRPG
{
    public partial class CreationAventurier : Form
    {
        public CreationAventurier()
        {
            InitializeComponent();

            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Hide();
            MenuJeu menuJeu = new MenuJeu();
            menuJeu.ShowDialog();

        }

    }
}
