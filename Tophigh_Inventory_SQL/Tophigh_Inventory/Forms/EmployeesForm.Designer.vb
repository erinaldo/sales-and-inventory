<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeesForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboidtype = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.txtidno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtdob = New System.Windows.Forms.DateTimePicker()
        Me.txtlname = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtmname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnsave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btncancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnstart = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnimagesave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.picguest = New System.Windows.Forms.PictureBox()
        Me.txtcheckemp = New System.Windows.Forms.TextBox()
        Me.txtpicname = New System.Windows.Forms.TextBox()
        Me.txtempcheck = New System.Windows.Forms.TextBox()
        Me.txtempid = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtnextofkin = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtmobile = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbocountry = New System.Windows.Forms.ComboBox()
        Me.txtcity = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtadd1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbodesignation = New System.Windows.Forms.ComboBox()
        Me.txtcomments = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtAllowa = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtbasSal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.picguest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboidtype)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboGender)
        Me.GroupBox1.Controls.Add(Me.txtfname)
        Me.GroupBox1.Controls.Add(Me.txtidno)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtdob)
        Me.GroupBox1.Controls.Add(Me.txtlname)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtmname)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 203)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee Details"
        '
        'cboidtype
        '
        Me.cboidtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboidtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboidtype.FormattingEnabled = True
        Me.cboidtype.Items.AddRange(New Object() {"Passport", "Voter ID", "Ghana Card", "Driver License"})
        Me.cboidtype.Location = New System.Drawing.Point(85, 150)
        Me.cboidtype.Name = "cboidtype"
        Me.cboidtype.Size = New System.Drawing.Size(121, 21)
        Me.cboidtype.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "ID Type"
        '
        'cboGender
        '
        Me.cboGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cboGender.Location = New System.Drawing.Point(85, 125)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(121, 21)
        Me.cboGender.TabIndex = 45
        '
        'txtfname
        '
        Me.txtfname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfname.Location = New System.Drawing.Point(85, 21)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(253, 20)
        Me.txtfname.TabIndex = 3
        '
        'txtidno
        '
        Me.txtidno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidno.Location = New System.Drawing.Point(85, 177)
        Me.txtidno.Name = "txtidno"
        Me.txtidno.Size = New System.Drawing.Size(253, 20)
        Me.txtidno.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "ID Number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Gender"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Date of birth"
        '
        'dtdob
        '
        Me.dtdob.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdob.Location = New System.Drawing.Point(85, 99)
        Me.dtdob.Name = "dtdob"
        Me.dtdob.Size = New System.Drawing.Size(98, 20)
        Me.dtdob.TabIndex = 8
        '
        'txtlname
        '
        Me.txtlname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlname.Location = New System.Drawing.Point(85, 73)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(253, 20)
        Me.txtlname.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Last Name"
        '
        'txtmname
        '
        Me.txtmname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmname.Location = New System.Drawing.Point(85, 47)
        Me.txtmname.Name = "txtmname"
        Me.txtmname.Size = New System.Drawing.Size(253, 20)
        Me.txtmname.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Middle Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "First Name"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnsave, Me.ToolStripSeparator2, Me.btncancel, Me.ToolStripSeparator3, Me.btnload, Me.ToolStripSeparator4, Me.btnstart, Me.ToolStripSeparator6, Me.btnimagesave, Me.ToolStripSeparator7, Me.btnStop})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(721, 25)
        Me.ToolStrip1.TabIndex = 45
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnsave
        '
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(51, 22)
        Me.btnsave.Text = "Save"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btncancel
        '
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(63, 22)
        Me.btncancel.Text = "Cancel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnload
        '
        Me.btnload.Image = CType(resources.GetObject("btnload.Image"), System.Drawing.Image)
        Me.btnload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnload.Name = "btnload"
        Me.btnload.Size = New System.Drawing.Size(53, 22)
        Me.btnload.Text = "Load"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnstart
        '
        Me.btnstart.Image = CType(resources.GetObject("btnstart.Image"), System.Drawing.Image)
        Me.btnstart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnstart.Name = "btnstart"
        Me.btnstart.Size = New System.Drawing.Size(51, 22)
        Me.btnstart.Text = "Start"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnimagesave
        '
        Me.btnimagesave.Image = CType(resources.GetObject("btnimagesave.Image"), System.Drawing.Image)
        Me.btnimagesave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnimagesave.Name = "btnimagesave"
        Me.btnimagesave.Size = New System.Drawing.Size(53, 22)
        Me.btnimagesave.Text = "Snap"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'btnStop
        '
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(51, 22)
        Me.btnStop.Text = "Stop"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lstDevices)
        Me.GroupBox5.Controls.Add(Me.picguest)
        Me.GroupBox5.Controls.Add(Me.txtcheckemp)
        Me.GroupBox5.Controls.Add(Me.txtpicname)
        Me.GroupBox5.Controls.Add(Me.txtempcheck)
        Me.GroupBox5.Controls.Add(Me.txtempid)
        Me.GroupBox5.Location = New System.Drawing.Point(369, 35)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(342, 180)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Emp Photo"
        '
        'lstDevices
        '
        Me.lstDevices.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lstDevices.FormattingEnabled = True
        Me.lstDevices.Location = New System.Drawing.Point(192, 19)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(136, 147)
        Me.lstDevices.TabIndex = 36
        '
        'picguest
        '
        Me.picguest.BackColor = System.Drawing.Color.White
        Me.picguest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picguest.Image = Global.Tophigh_Inventory.My.Resources.Resources.image
        Me.picguest.Location = New System.Drawing.Point(14, 19)
        Me.picguest.Name = "picguest"
        Me.picguest.Size = New System.Drawing.Size(154, 146)
        Me.picguest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picguest.TabIndex = 35
        Me.picguest.TabStop = False
        '
        'txtcheckemp
        '
        Me.txtcheckemp.Location = New System.Drawing.Point(200, 68)
        Me.txtcheckemp.Name = "txtcheckemp"
        Me.txtcheckemp.Size = New System.Drawing.Size(100, 20)
        Me.txtcheckemp.TabIndex = 24
        '
        'txtpicname
        '
        Me.txtpicname.Location = New System.Drawing.Point(46, 115)
        Me.txtpicname.Name = "txtpicname"
        Me.txtpicname.Size = New System.Drawing.Size(100, 20)
        Me.txtpicname.TabIndex = 53
        '
        'txtempcheck
        '
        Me.txtempcheck.Location = New System.Drawing.Point(46, 73)
        Me.txtempcheck.Name = "txtempcheck"
        Me.txtempcheck.Size = New System.Drawing.Size(100, 20)
        Me.txtempcheck.TabIndex = 54
        '
        'txtempid
        '
        Me.txtempid.BackColor = System.Drawing.Color.White
        Me.txtempid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtempid.Location = New System.Drawing.Point(200, 115)
        Me.txtempid.Name = "txtempid"
        Me.txtempid.ReadOnly = True
        Me.txtempid.Size = New System.Drawing.Size(100, 20)
        Me.txtempid.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtnextofkin)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtemail)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtmobile)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cbocountry)
        Me.GroupBox2.Controls.Add(Me.txtcity)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtadd1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 237)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(351, 177)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Address"
        '
        'txtnextofkin
        '
        Me.txtnextofkin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnextofkin.Location = New System.Drawing.Point(75, 149)
        Me.txtnextofkin.Name = "txtnextofkin"
        Me.txtnextofkin.Size = New System.Drawing.Size(253, 20)
        Me.txtnextofkin.TabIndex = 23
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 151)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Next of Kin"
        '
        'txtemail
        '
        Me.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtemail.Location = New System.Drawing.Point(75, 123)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(253, 20)
        Me.txtemail.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Email"
        '
        'txtmobile
        '
        Me.txtmobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmobile.Location = New System.Drawing.Point(75, 97)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.Size = New System.Drawing.Size(253, 20)
        Me.txtmobile.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Mobile"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Country"
        '
        'cbocountry
        '
        Me.cbocountry.AutoCompleteCustomSource.AddRange(New String() {"Afghanistan", "Africa", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua & Barbuda", "Antilles, Netherlands", "Arabia, Saudi", "Argentina", "Armenia", "Aruba", "Asia", "Australia", "Austria", "Azerbaijan", "Bahamas, The", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean T.", "British Virgin Islands", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Caribbean, the", "Cayman Islands", "Central African Republic", "Central America", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo", "Congo, Dem. Rep. of the", "Cook Islands", "Costa Rica", "Cote D'Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor (Timor-Leste)", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Europe", "European Union", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Terr.", "Gabon", "Gambia, the", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey and Alderney", "Guiana, French", "Guinea", "Guinea-Bissau", "Guinea, Equatorial", "Guyana", "Haiti", "Heard & McDonald Is.(AU)", "Holy See (Vatican)", "Honduras", "Hong Kong, (China)", "Hungary", "Iceland", "India", "Indonesia", "Iran, Islamic Republic of", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast (Cote d'Ivoire)", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea Dem. People's Rep.", "Korea, (South) Republic of", "Kosovo", "Kuwait", "Kyrgyzstan", "Lao People's Democ. Rep.", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao, (China)", "Macedonia, TFYR", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Man, Isle of", "Marshall Islands", "Martinique (FR)", "Mauritania", "Mauritius", "Mayotte (FR)", "Mexico", "Micronesia, Fed. States of", "Middle East", "Moldova, Republic of", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar (ex-Burma)", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "North America", "Northern Mariana Islands", "Norway", "Oceania", "Oman", "Pakistan", "Palau", "Palestinian Territory", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn Island", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion (FR)", "Romania", "Russia (Russian Fed.)", "Rwanda", "Sahara, Western", "Saint Barthelemy (FR)", "Saint Helena (UK)", "Saint Kitts and Nevis", "Saint Lucia", "Saint Martin (FR)", "S Pierre & Miquelon(FR)", "S Vincent & Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South America", "S.George & S.Sandwich", "South Sudan", "Spain", "Sri Lanka (ex-Ceilan)", "Sudan", "Suriname", "Svalbard & Jan Mayen Is.", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic", "Taiwan", "Tajikistan", "Tanzania, United Rep. of", "Thailand", "Timor-Leste (East Timor)", "Togo", "Tokelau", "Tonga", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Is.", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "US Minor Outlying Isl.", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican (Holy See)", "Venezuela", "Viet Nam", "Virgin Islands, British", "Virgin Islands, U.S.", "Wallis and Futuna", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"})
        Me.cbocountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbocountry.FormattingEnabled = True
        Me.cbocountry.Items.AddRange(New Object() {"Afghanistan", "Africa", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua & Barbuda", "Antilles, Netherlands", "Arabia, Saudi", "Argentina", "Armenia", "Aruba", "Asia", "Australia", "Austria", "Azerbaijan", "Bahamas, The", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean T.", "British Virgin Islands", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Caribbean, the", "Cayman Islands", "Central African Republic", "Central America", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo", "Congo, Dem. Rep. of the", "Cook Islands", "Costa Rica", "Cote D'Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor (Timor-Leste)", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Europe", "European Union", "Falkland Islands (Malvinas)", "Faroe Islands", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Terr.", "Gabon", "Gambia, the", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey and Alderney", "Guiana, French", "Guinea", "Guinea-Bissau", "Guinea, Equatorial", "Guyana", "Haiti", "Heard & McDonald Is.(AU)", "Holy See (Vatican)", "Honduras", "Hong Kong, (China)", "Hungary", "Iceland", "India", "Indonesia", "Iran, Islamic Republic of", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast (Cote d'Ivoire)", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea Dem. People's Rep.", "Korea, (South) Republic of", "Kosovo", "Kuwait", "Kyrgyzstan", "Lao People's Democ. Rep.", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao, (China)", "Macedonia, TFYR", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Man, Isle of", "Marshall Islands", "Martinique (FR)", "Mauritania", "Mauritius", "Mayotte (FR)", "Mexico", "Micronesia, Fed. States of", "Middle East", "Moldova, Republic of", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar (ex-Burma)", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "North America", "Northern Mariana Islands", "Norway", "Oceania", "Oman", "Pakistan", "Palau", "Palestinian Territory", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn Island", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion (FR)", "Romania", "Russia (Russian Fed.)", "Rwanda", "Sahara, Western", "Saint Barthelemy (FR)", "Saint Helena (UK)", "Saint Kitts and Nevis", "Saint Lucia", "Saint Martin (FR)", "S Pierre & Miquelon(FR)", "S Vincent & Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South America", "S.George & S.Sandwich", "South Sudan", "Spain", "Sri Lanka (ex-Ceilan)", "Sudan", "Suriname", "Svalbard & Jan Mayen Is.", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic", "Taiwan", "Tajikistan", "Tanzania, United Rep. of", "Thailand", "Timor-Leste (East Timor)", "Togo", "Tokelau", "Tonga", "Trinidad & Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Is.", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "US Minor Outlying Isl.", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican (Holy See)", "Venezuela", "Viet Nam", "Virgin Islands, British", "Virgin Islands, U.S.", "Wallis and Futuna", "Western Sahara", "Yemen", "Zambia", "Zimbabwe"})
        Me.cbocountry.Location = New System.Drawing.Point(75, 70)
        Me.cbocountry.Name = "cbocountry"
        Me.cbocountry.Size = New System.Drawing.Size(253, 21)
        Me.cbocountry.TabIndex = 14
        '
        'txtcity
        '
        Me.txtcity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcity.Location = New System.Drawing.Point(75, 44)
        Me.txtcity.Name = "txtcity"
        Me.txtcity.Size = New System.Drawing.Size(162, 20)
        Me.txtcity.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "City"
        '
        'txtadd1
        '
        Me.txtadd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtadd1.Location = New System.Drawing.Point(75, 18)
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(253, 20)
        Me.txtadd1.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Line 1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "477163493.jpg")
        Me.ImageList1.Images.SetKeyName(1, "Actions-contact-new-icon.png")
        Me.ImageList1.Images.SetKeyName(2, "Actions-document-print-preview-icon.png")
        Me.ImageList1.Images.SetKeyName(3, "Apps-Pdf-icon.png")
        Me.ImageList1.Images.SetKeyName(4, "bank-icon.png")
        Me.ImageList1.Images.SetKeyName(5, "Botton1.png")
        Me.ImageList1.Images.SetKeyName(6, "button 2.png")
        Me.ImageList1.Images.SetKeyName(7, "Button-Refresh-icon.png")
        Me.ImageList1.Images.SetKeyName(8, "checklist-icon.png")
        Me.ImageList1.Images.SetKeyName(9, "city-icon.png")
        Me.ImageList1.Images.SetKeyName(10, "Clipboard-icon.png")
        Me.ImageList1.Images.SetKeyName(11, "coal-power-plant-icon.png")
        Me.ImageList1.Images.SetKeyName(12, "COMPOUND (1).JPG")
        Me.ImageList1.Images.SetKeyName(13, "Credit-paypal-icon.png")
        Me.ImageList1.Images.SetKeyName(14, "delete-icon.png")
        Me.ImageList1.Images.SetKeyName(15, "Document-Chart-icon.png")
        Me.ImageList1.Images.SetKeyName(16, "document-edit-icon.png")
        Me.ImageList1.Images.SetKeyName(17, "document-icon.png")
        Me.ImageList1.Images.SetKeyName(18, "dollar-icon.png")
        Me.ImageList1.Images.SetKeyName(19, "download.jpg")
        Me.ImageList1.Images.SetKeyName(20, "Ecommerce-Product-icon.png")
        Me.ImageList1.Images.SetKeyName(21, "Ecommerce-Return-Purchase-icon.png")
        Me.ImageList1.Images.SetKeyName(22, "Extract-todays-changes-icon.png")
        Me.ImageList1.Images.SetKeyName(23, "Files-Document-icon.png")
        Me.ImageList1.Images.SetKeyName(24, "Files-New-File-icon.png")
        Me.ImageList1.Images.SetKeyName(25, "fish-icon.png")
        Me.ImageList1.Images.SetKeyName(26, "fixed.png")
        Me.ImageList1.Images.SetKeyName(27, "Food-List-Ingredients-icon.png")
        Me.ImageList1.Images.SetKeyName(28, "fork-3-icon.png")
        Me.ImageList1.Images.SetKeyName(29, "Groups-Meeting-Light-icon.png")
        Me.ImageList1.Images.SetKeyName(30, "icon_store_records.png")
        Me.ImageList1.Images.SetKeyName(31, "inventory-maintenance-icon.png")
        Me.ImageList1.Images.SetKeyName(32, "Invoice-icon (1).png")
        Me.ImageList1.Images.SetKeyName(33, "invoice-icon.png")
        Me.ImageList1.Images.SetKeyName(34, "load_upload.png")
        Me.ImageList1.Images.SetKeyName(35, "Lock-Lock-icon.png")
        Me.ImageList1.Images.SetKeyName(36, "Lock-Unlock-icon.png")
        Me.ImageList1.Images.SetKeyName(37, "Mail-icon.png")
        Me.ImageList1.Images.SetKeyName(38, "media_playback_start.png")
        Me.ImageList1.Images.SetKeyName(39, "Microsoft-Excel-2010-icon.png")
        Me.ImageList1.Images.SetKeyName(40, "Money-icon.png")
        Me.ImageList1.Images.SetKeyName(41, "new-homepage-hero-f128d26c.jpg")
        Me.ImageList1.Images.SetKeyName(42, "NewIcon.ico")
        Me.ImageList1.Images.SetKeyName(43, "Notes-2-icon.png")
        Me.ImageList1.Images.SetKeyName(44, "numbers-white-icon.png")
        Me.ImageList1.Images.SetKeyName(45, "payment-icon.png")
        Me.ImageList1.Images.SetKeyName(46, "player_stop.png")
        Me.ImageList1.Images.SetKeyName(47, "Preppy-icon.png")
        Me.ImageList1.Images.SetKeyName(48, "price_tag.png")
        Me.ImageList1.Images.SetKeyName(49, "printer-icon.png")
        Me.ImageList1.Images.SetKeyName(50, "SABCOLOGO.png")
        Me.ImageList1.Images.SetKeyName(51, "sale-icon.png")
        Me.ImageList1.Images.SetKeyName(52, "save-as-icon.png")
        Me.ImageList1.Images.SetKeyName(53, "Save-icon.png")
        Me.ImageList1.Images.SetKeyName(54, "search-b-icon.png")
        Me.ImageList1.Images.SetKeyName(55, "Search-icon.png")
        Me.ImageList1.Images.SetKeyName(56, "Settings-icon.png")
        Me.ImageList1.Images.SetKeyName(57, "stock-vector-tax-icon-over-orange-background-vector-illustration-176661752.jpg")
        Me.ImageList1.Images.SetKeyName(58, "to-do-list-cheked-all-icon.png")
        Me.ImageList1.Images.SetKeyName(59, "university-icon.png")
        Me.ImageList1.Images.SetKeyName(60, "User-Interface-Password-icon.png")
        Me.ImageList1.Images.SetKeyName(61, "Word-2-icon.png")
        Me.ImageList1.Images.SetKeyName(62, "WP_20170415_18_23_22_Pro.jpg")
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.cbodesignation)
        Me.GroupBox4.Controls.Add(Me.txtcomments)
        Me.GroupBox4.Location = New System.Drawing.Point(367, 221)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(342, 78)
        Me.GroupBox4.TabIndex = 52
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Comments"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Designation"
        '
        'cbodesignation
        '
        Me.cbodesignation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbodesignation.FormattingEnabled = True
        Me.cbodesignation.Items.AddRange(New Object() {"Cashier", "Admin", "Pharmacist", "Messenger", "Driver", "Accountant", "Cleaner", "Receptionist", "Manager"})
        Me.cbodesignation.Location = New System.Drawing.Point(75, 49)
        Me.cbodesignation.Name = "cbodesignation"
        Me.cbodesignation.Size = New System.Drawing.Size(261, 21)
        Me.cbodesignation.TabIndex = 1
        '
        'txtcomments
        '
        Me.txtcomments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcomments.Location = New System.Drawing.Point(11, 16)
        Me.txtcomments.Multiline = True
        Me.txtcomments.Name = "txtcomments"
        Me.txtcomments.Size = New System.Drawing.Size(327, 25)
        Me.txtcomments.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAllowa)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtbasSal)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(369, 307)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(340, 100)
        Me.GroupBox3.TabIndex = 53
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Salaries && Allowance"
        '
        'txtAllowa
        '
        Me.txtAllowa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAllowa.Location = New System.Drawing.Point(82, 55)
        Me.txtAllowa.Name = "txtAllowa"
        Me.txtAllowa.Size = New System.Drawing.Size(157, 20)
        Me.txtAllowa.TabIndex = 3
        Me.txtAllowa.Text = "0.00"
        Me.txtAllowa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Allowance"
        '
        'txtbasSal
        '
        Me.txtbasSal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbasSal.Location = New System.Drawing.Point(82, 26)
        Me.txtbasSal.Name = "txtbasSal"
        Me.txtbasSal.Size = New System.Drawing.Size(157, 20)
        Me.txtbasSal.TabIndex = 1
        Me.txtbasSal.Text = "0.00"
        Me.txtbasSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Basic Salary"
        '
        'EmployeesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(721, 417)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "EmployeesForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Employees"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.picguest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboGender As ComboBox
    Friend WithEvents txtfname As TextBox
    Friend WithEvents txtidno As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtdob As DateTimePicker
    Friend WithEvents txtlname As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtmname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnsave As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btncancel As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnload As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnstart As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btnimagesave As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnStop As ToolStripButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lstDevices As ListBox
    Friend WithEvents txtempid As TextBox
    Friend WithEvents picguest As PictureBox
    Friend WithEvents txtcheckemp As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtnextofkin As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtemail As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtmobile As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbocountry As ComboBox
    Friend WithEvents txtcity As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtadd1 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents sfdImage As SaveFileDialog
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cbodesignation As ComboBox
    Friend WithEvents txtcomments As TextBox
    Friend WithEvents cboidtype As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtpicname As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtAllowa As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtbasSal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtempcheck As TextBox
End Class
