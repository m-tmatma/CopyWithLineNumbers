﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyWithLineNumbers
{
    public partial class OptionsControl : UserControl
    {
        private OptionsPageSetting settingOptionsPage;

        public OptionsControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Gets or sets the reference to the underlying OptionsPage object.
        /// </summary>
        public OptionsPageSetting OptionsPage
        {
            get
            {
                return settingOptionsPage;
            }
            set
            {
                settingOptionsPage = value;
            }
        }
    }
}