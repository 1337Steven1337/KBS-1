using System;
using System.Drawing;
using System.Windows.Forms;
using TheHunt.View.Designer;

namespace TheHunt
{
    public partial class form_selectlevel : Form
    {
        public form_startscreen formulier;
        public string nextStage;
        public form_selectlevel(form_startscreen form, string nextStage)
        {
            InitializeComponent();
            this.formulier = form;
            this.nextStage = nextStage;
            
        }

        private void form_selectlevel_Load(object sender, EventArgs e)
        {
            this.Size = formulier.Size;
            this.Location = formulier.Location;

            if (nextStage == "spelen")
            {
                //Assigns Eventhandlers to buttons
                this.level1Btn.Click += new EventHandler(this.speelSpel);
                this.level2Btn.Click += new EventHandler(this.speelSpel);
                this.level3Btn.Click += new EventHandler(this.speelSpel);
                this.level4Btn.Click += new EventHandler(this.speelSpel);
                this.level5Btn.Click += new EventHandler(this.speelSpel);

                this.custom1Btn.Click += new EventHandler(this.speelSpel);
                this.custom2Btn.Click += new EventHandler(this.speelSpel);
                this.custom3Btn.Click += new EventHandler(this.speelSpel);
                this.custom4Btn.Click += new EventHandler(this.speelSpel);
                this.custom5Btn.Click += new EventHandler(this.speelSpel);
                this.custom6Btn.Click += new EventHandler(this.speelSpel);
                this.custom7Btn.Click += new EventHandler(this.speelSpel);
                this.custom8Btn.Click += new EventHandler(this.speelSpel);
                this.custom9Btn.Click += new EventHandler(this.speelSpel);
                this.custom10Btn.Click += new EventHandler(this.speelSpel);


                //Loop through all properties
                foreach (var propertyInfo in Properties.Levels.Default.GetType().GetProperties())
                {
                    //Checks if property is readable
                    if (propertyInfo.CanRead)
                    {
                        //Makes sure there are no parameters needed (this fixes the TargetParameterCountException while enumerating)
                        if (propertyInfo.GetIndexParameters().Length == 0) 
                        {
                            //Assigns current property value to a variable
                            var waarde = propertyInfo.GetValue(Properties.Levels.Default, null).ToString();


                            //Checks when a level is "non-existent"
                            if (waarde == "")
                            {
                                //Disables and greys out the button
                                switch (propertyInfo.Name)
                                {
                                    case "level1":
                                        level1Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        level1Btn.Enabled = false;
                                        break;
                                    case "level2":
                                        level2Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        level2Btn.Enabled = false;
                                        break;
                                    case "level3":
                                        level3Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        level3Btn.Enabled = false;
                                        break;
                                    case "level4":
                                        level4Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        level4Btn.Enabled = false;
                                        break;
                                    case "level5":
                                        level5Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        level5Btn.Enabled = false;
                                        break;
                                    case "customlv1":
                                        custom1Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom1Btn.Enabled = false;
                                        break;
                                    case "customlv2":
                                        custom2Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom2Btn.Enabled = false;
                                        break;
                                    case "customlv3":
                                        custom3Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom3Btn.Enabled = false;
                                        break;
                                    case "customlv4":
                                        custom4Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom4Btn.Enabled = false;
                                        break;
                                    case "customlv5":
                                        custom5Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom5Btn.Enabled = false;
                                        break;
                                    case "customlv6":
                                        custom6Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom6Btn.Enabled = false;
                                        break;
                                    case "customlv7":
                                        custom7Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom7Btn.Enabled = false;
                                        break;
                                    case "customlv8":
                                        custom8Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom8Btn.Enabled = false;
                                        break;
                                    case "customlv9":
                                        custom9Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom9Btn.Enabled = false;
                                        break;
                                    case "customlv10":
                                        custom10Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                                        custom10Btn.Enabled = false;
                                        break;
                                }
                            }
                        }
                        else
                        {

                        }


                    }
                } 
                    }
                    else if (nextStage == "designerMode")
            {
                level1Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                level2Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                level3Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                level4Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                level5Btn.BackgroundImage = Properties.Resources.TemplateDisabled;
                level1Btn.Enabled = false;
                level2Btn.Enabled = false;
                level3Btn.Enabled = false;
                level4Btn.Enabled = false;
                level5Btn.Enabled = false;
                this.level1Btn.Click += new EventHandler(this.designLevel);
                this.level2Btn.Click += new EventHandler(this.designLevel);
                this.level3Btn.Click += new EventHandler(this.designLevel);
                this.level4Btn.Click += new EventHandler(this.designLevel);
                this.level5Btn.Click += new EventHandler(this.designLevel);

                this.custom1Btn.Click += new EventHandler(this.designLevel);
                this.custom2Btn.Click += new EventHandler(this.designLevel);
                this.custom3Btn.Click += new EventHandler(this.designLevel);
                this.custom4Btn.Click += new EventHandler(this.designLevel);
                this.custom5Btn.Click += new EventHandler(this.designLevel);
                this.custom6Btn.Click += new EventHandler(this.designLevel);
                this.custom7Btn.Click += new EventHandler(this.designLevel);
                this.custom8Btn.Click += new EventHandler(this.designLevel);
                this.custom9Btn.Click += new EventHandler(this.designLevel);
                this.custom10Btn.Click += new EventHandler(this.designLevel);
            }


            this.level1Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.level2Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.level3Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.level4Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.level5Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);

            this.custom1Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom2Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom3Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom4Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom5Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom6Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom7Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom8Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom9Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);
            this.custom10Btn.Size = new Size(this.Size.Width / 7, this.Size.Height / 12);

            this.backBtn.Size = new Size(this.Size.Width/5, this.Size.Height / 11);

            this.backBtn.Location = new Point(this.Size.Width / 2 - backBtn.Width/2 , this.Size.Height - (int)(backBtn.Height * 1.5));

            this.level1Btn.Location = new Point(this.Size.Width / 2 - level1Btn.Width / 2 - (int)(level1Btn.Width * 1.5), this.Size.Height / 2 - (int)(3 * level1Btn.Height));
            this.level2Btn.Location = new Point(this.Size.Width / 2 - level2Btn.Width / 2 - (int)(level2Btn.Width * 1.5), this.Size.Height / 2 - (int)(1.75 * level2Btn.Height));
            this.level3Btn.Location = new Point(this.Size.Width / 2 - level3Btn.Width / 2 - (int)(level3Btn.Width * 1.5), this.Size.Height/2 - (int)(0.5 * level3Btn.Height));
            this.level4Btn.Location = new Point(this.Size.Width / 2 - level4Btn.Width / 2 - (int)(level4Btn.Width * 1.5), this.Size.Height / 2 + (int)(0.75 * level4Btn.Height));
            this.level5Btn.Location = new Point(this.Size.Width / 2 - level5Btn.Width / 2 - (int)(level5Btn.Width * 1.5), this.Size.Height / 2 + (int)(2 * level5Btn.Height));

            this.custom1Btn.Location = new Point(this.Size.Width / 2 - custom1Btn.Width / 2, this.Size.Height / 2 - (int)(3 * custom1Btn.Height));
            this.custom2Btn.Location = new Point(this.Size.Width / 2 - custom2Btn.Width / 2, this.Size.Height / 2 - (int)(1.75 * custom2Btn.Height));
            this.custom3Btn.Location = new Point(this.Size.Width / 2 - custom3Btn.Width / 2, this.Size.Height / 2 - (int)(0.5 * custom3Btn.Height));
            this.custom4Btn.Location = new Point(this.Size.Width / 2 - custom4Btn.Width / 2, this.Size.Height / 2 + (int)(0.75 * custom4Btn.Height));
            this.custom5Btn.Location = new Point(this.Size.Width / 2 - custom5Btn.Width / 2, this.Size.Height / 2 + (int)(2 * custom5Btn.Height));


            this.custom6Btn.Location = new Point(this.Size.Width / 2 + custom6Btn.Width / 2 + (int)(custom6Btn.Width * 0.5), this.Size.Height / 2 - (int)(3 * custom6Btn.Height));
            this.custom7Btn.Location = new Point(this.Size.Width / 2 + custom7Btn.Width / 2 + (int)(custom7Btn.Width * 0.5), this.Size.Height / 2 - (int)(1.75 * custom7Btn.Height));
            this.custom8Btn.Location = new Point(this.Size.Width / 2 + custom8Btn.Width / 2 + (int)(custom8Btn.Width * 0.5), this.Size.Height / 2 - (int)(0.5 * custom8Btn.Height));
            this.custom9Btn.Location = new Point(this.Size.Width / 2 + custom9Btn.Width / 2 + (int)(custom9Btn.Width * 0.5), this.Size.Height / 2 + (int)(0.75 * custom9Btn.Height));
            this.custom10Btn.Location = new Point(this.Size.Width / 2 + custom10Btn.Width / 2 + (int)(custom10Btn.Width * 0.5), this.Size.Height / 2 + (int)(2 * custom10Btn.Height));
            
            this.label1.Size = new Size(600,100);
            this.label1.Location = new Point(this.Size.Width / 2 - 300, 100);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            formulier.Show();
            this.Close();
        }

        private void speelSpel(object sender, EventArgs e)
        {
            string levelToLoad = "";
            if (sender == this.level1Btn)
            {
                levelToLoad = "level1";
            }
            else if (sender == this.level2Btn)
            {
                levelToLoad = "level2";
            }
            else if (sender == this.level3Btn)
            {
                levelToLoad = "level3";
            }
            else if (sender == this.level4Btn)
            {
                levelToLoad = "level4";
            }
            else if (sender == this.level5Btn)
            {
                levelToLoad = "level5";
            }
            else if (sender == this.custom1Btn)
            {
                levelToLoad = "customlv1";
            }
            else if (sender == this.custom2Btn)
            {
                levelToLoad = "customlv2";
            }
            else if (sender == this.custom3Btn)
            {
                levelToLoad = "customlv3";
            }
            else if (sender == this.custom4Btn)
            {
                levelToLoad = "customlv4";
            }
            else if (sender == this.custom5Btn)
            {
                levelToLoad = "customlv5";
            }
            else if (sender == this.custom6Btn)
            {
                levelToLoad = "customlv6";
            }
            else if (sender == this.custom7Btn)
            {
                levelToLoad = "customlv7";
            }
            else if (sender == this.custom8Btn)
            {
                levelToLoad = "customlv8";
            }
            else if (sender == this.custom9Btn)
            {
                levelToLoad = "customlv9";
            }
            else if (sender == this.custom10Btn)
            {
                levelToLoad = "customlv10";
            }

            this.Close();
            Game game = new Game(formulier, levelToLoad);
            game.Show();

        }

        private void designLevel(object sender, EventArgs e)
        {
            string levelToLoad = "";
            string levelID = "";
            if (sender == this.custom1Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv1;
                levelID = "customlv1";
            }
            else if (sender == this.custom2Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv2;
                levelID = "customlv2";
            }
            else if (sender == this.custom3Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv3;
                levelID = "customlv3";
            }
            else if (sender == this.custom4Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv4;
                levelID = "customlv4";
            }
            else if (sender == this.custom5Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv5;
                levelID = "customlv5";
            }
            else if (sender == this.custom6Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv6;
                levelID = "customlv6";
            }
            else if (sender == this.custom7Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv7;
                levelID = "customlv7";
            }
            else if (sender == this.custom8Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv8;
                levelID = "customlv8";
            }
            else if (sender == this.custom9Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv9;
                levelID = "customlv9";
            }
            else if (sender == this.custom10Btn)
            {
                levelToLoad = Properties.Levels.Default.customlv10;
                levelID = "customlv10";
            }
            this.Close();
            Designer design = new Designer(formulier, levelToLoad,levelID);
            design.Show();
        }


    }
}
