﻿using System;
using System.Reflection;

namespace XJ.Unity3D.GUI.FieldGUIComponents
{
    public class FloatGUI : FieldGUIComponent
    {
        #region Field

        private XJ.Unity3D.GUI.FloatGUI gui;

        #endregion Field

        #region Constructor

        public FloatGUI(System.Object data, FieldInfo fieldInfo, GUIAttribute guiAttribute)
            :base(data, fieldInfo, guiAttribute)
        {
            this.gui = new GUI.FloatGUI();
            Load();
        }

        #endregion Constructor

        #region Method

        public override void Controller()
        {
            if (base.guiAttribute != null)
            {
                if (!float.IsNaN(base.guiAttribute.MinValue)
                    && !float.IsNaN(base.guiAttribute.MaxValue))
                {
                    this.gui.Controller(base.guiAttribute.Title,
                                        (int)base.guiAttribute.MinValue,
                                        (int)base.guiAttribute.MaxValue);
                }
                else
                {
                    this.gui.Controller(base.guiAttribute.Title);
                }
            }
            else
            {
                this.gui.Controller(ToTitleCase(base.fieldInfo.Name));
            }

            Save();
        }

        public override void Save()
        {
            base.fieldInfo.SetValue(base.data, this.gui.Value);
        }

        public override void Load()
        {
            this.gui.Value = (float)base.fieldInfo.GetValue(base.data);
        }

        #endregion Method
    }
}