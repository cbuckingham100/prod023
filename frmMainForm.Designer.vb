<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMainForm
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents mnuBitTest As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnuDiagnostics As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents tmrSecTick As System.Windows.Forms.Timer
	Public WithEvents txtCycle As System.Windows.Forms.TextBox
	Public WithEvents txtWait As System.Windows.Forms.TextBox
	Public WithEvents cmdSave As System.Windows.Forms.Button
	Public WithEvents tmrClearTxtSerial As System.Windows.Forms.Timer
	Public WithEvents tmrOvrCountDown As System.Windows.Forms.Timer
	Public WithEvents tmrRemoveOkSignal As System.Windows.Forms.Timer
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents tmrCheckShotCompleteAuto As System.Windows.Forms.Timer
	Public WithEvents tmrSecTickAuto As System.Windows.Forms.Timer
	Public WithEvents txtSerial As System.Windows.Forms.TextBox
	Public WithEvents tmrCheckShotComplete As System.Windows.Forms.Timer
	Public WithEvents _optHeadType_0 As System.Windows.Forms.RadioButton
	Public WithEvents cmdQuit As System.Windows.Forms.Button
	Public WithEvents chkOkToDispense As System.Windows.Forms.CheckBox
	Public WithEvents lblShotCompletePrompt As System.Windows.Forms.Label
	Public WithEvents lblShotComplete As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents _optHeadType_3 As System.Windows.Forms.RadioButton
	Public WithEvents _optHeadType_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optHeadType_1 As System.Windows.Forms.RadioButton
	Public WithEvents frmPrintHeadType As System.Windows.Forms.GroupBox
	Public WithEvents lblScore As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lblTicker As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblHeadDescription As System.Windows.Forms.Label
	Public WithEvents optHeadType As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainForm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip()
        Me.mnuDiagnostics = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBitTest = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrSecTick = New System.Windows.Forms.Timer(Me.components)
        Me.txtCycle = New System.Windows.Forms.TextBox()
        Me.txtWait = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.tmrClearTxtSerial = New System.Windows.Forms.Timer(Me.components)
        Me.tmrOvrCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRemoveOkSignal = New System.Windows.Forms.Timer(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.tmrCheckShotCompleteAuto = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSecTickAuto = New System.Windows.Forms.Timer(Me.components)
        Me.txtSerial = New System.Windows.Forms.TextBox()
        Me.tmrCheckShotComplete = New System.Windows.Forms.Timer(Me.components)
        Me._optHeadType_0 = New System.Windows.Forms.RadioButton()
        Me.cmdQuit = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.chkOkToDispense = New System.Windows.Forms.CheckBox()
        Me.lblShotCompletePrompt = New System.Windows.Forms.Label()
        Me.lblShotComplete = New System.Windows.Forms.Label()
        Me._optHeadType_3 = New System.Windows.Forms.RadioButton()
        Me._optHeadType_2 = New System.Windows.Forms.RadioButton()
        Me._optHeadType_1 = New System.Windows.Forms.RadioButton()
        Me.frmPrintHeadType = New System.Windows.Forms.GroupBox()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTicker = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblHeadDescription = New System.Windows.Forms.Label()
        Me.optHeadType = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpPanel = New System.Windows.Forms.Panel()
        Me.btnRePot = New System.Windows.Forms.Button()
        Me.MainMenu1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.optHeadType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDiagnostics})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(530, 24)
        Me.MainMenu1.TabIndex = 22
        '
        'mnuDiagnostics
        '
        Me.mnuDiagnostics.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBitTest})
        Me.mnuDiagnostics.Name = "mnuDiagnostics"
        Me.mnuDiagnostics.Size = New System.Drawing.Size(80, 20)
        Me.mnuDiagnostics.Text = "&Diagnostics"
        '
        'mnuBitTest
        '
        Me.mnuBitTest.Name = "mnuBitTest"
        Me.mnuBitTest.Size = New System.Drawing.Size(111, 22)
        Me.mnuBitTest.Text = "Bit &Test"
        '
        'tmrSecTick
        '
        Me.tmrSecTick.Interval = 1000
        '
        'txtCycle
        '
        Me.txtCycle.AcceptsReturn = True
        Me.txtCycle.BackColor = System.Drawing.SystemColors.Window
        Me.txtCycle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCycle.Enabled = False
        Me.txtCycle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCycle.Location = New System.Drawing.Point(162, 447)
        Me.txtCycle.MaxLength = 0
        Me.txtCycle.Name = "txtCycle"
        Me.txtCycle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCycle.Size = New System.Drawing.Size(33, 20)
        Me.txtCycle.TabIndex = 16
        '
        'txtWait
        '
        Me.txtWait.AcceptsReturn = True
        Me.txtWait.BackColor = System.Drawing.SystemColors.Window
        Me.txtWait.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWait.Enabled = False
        Me.txtWait.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWait.Location = New System.Drawing.Point(162, 423)
        Me.txtWait.MaxLength = 0
        Me.txtWait.Name = "txtWait"
        Me.txtWait.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWait.Size = New System.Drawing.Size(33, 20)
        Me.txtWait.TabIndex = 14
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSave.Location = New System.Drawing.Point(207, 428)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSave.Size = New System.Drawing.Size(49, 33)
        Me.cmdSave.TabIndex = 13
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = False
        Me.cmdSave.Visible = False
        '
        'tmrClearTxtSerial
        '
        Me.tmrClearTxtSerial.Interval = 1
        '
        'tmrOvrCountDown
        '
        Me.tmrOvrCountDown.Interval = 1
        '
        'tmrRemoveOkSignal
        '
        Me.tmrRemoveOkSignal.Interval = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.CausesValidation = False
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(163, 521)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(189, 57)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'tmrCheckShotCompleteAuto
        '
        Me.tmrCheckShotCompleteAuto.Interval = 1
        '
        'tmrSecTickAuto
        '
        Me.tmrSecTickAuto.Enabled = True
        Me.tmrSecTickAuto.Interval = 1000
        '
        'txtSerial
        '
        Me.txtSerial.AcceptsReturn = True
        Me.txtSerial.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerial.Font = New System.Drawing.Font("Arial", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSerial.Location = New System.Drawing.Point(65, 89)
        Me.txtSerial.MaxLength = 0
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerial.Size = New System.Drawing.Size(399, 99)
        Me.txtSerial.TabIndex = 10
        Me.txtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tmrCheckShotComplete
        '
        Me.tmrCheckShotComplete.Interval = 1
        '
        '_optHeadType_0
        '
        Me._optHeadType_0.BackColor = System.Drawing.SystemColors.Control
        Me._optHeadType_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._optHeadType_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optHeadType.SetIndex(Me._optHeadType_0, CType(0, Short))
        Me._optHeadType_0.Location = New System.Drawing.Point(127, 297)
        Me._optHeadType_0.Name = "_optHeadType_0"
        Me._optHeadType_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optHeadType_0.Size = New System.Drawing.Size(129, 25)
        Me._optHeadType_0.TabIndex = 9
        Me._optHeadType_0.TabStop = True
        Me._optHeadType_0.Text = "Mk &5"
        Me._optHeadType_0.UseVisualStyleBackColor = False
        '
        'cmdQuit
        '
        Me.cmdQuit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdQuit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdQuit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdQuit.Location = New System.Drawing.Point(461, 545)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdQuit.Size = New System.Drawing.Size(57, 33)
        Me.cmdQuit.TabIndex = 7
        Me.cmdQuit.Text = "&Exit"
        Me.cmdQuit.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.chkOkToDispense)
        Me.Frame2.Controls.Add(Me.lblShotCompletePrompt)
        Me.Frame2.Controls.Add(Me.lblShotComplete)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(271, 281)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(145, 121)
        Me.Frame2.TabIndex = 4
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Dispense Control"
        '
        'chkOkToDispense
        '
        Me.chkOkToDispense.BackColor = System.Drawing.SystemColors.Control
        Me.chkOkToDispense.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkOkToDispense.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOkToDispense.Location = New System.Drawing.Point(16, 24)
        Me.chkOkToDispense.Name = "chkOkToDispense"
        Me.chkOkToDispense.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOkToDispense.Size = New System.Drawing.Size(121, 25)
        Me.chkOkToDispense.TabIndex = 5
        Me.chkOkToDispense.Text = "&OK to dispense"
        Me.chkOkToDispense.UseVisualStyleBackColor = False
        '
        'lblShotCompletePrompt
        '
        Me.lblShotCompletePrompt.BackColor = System.Drawing.SystemColors.Control
        Me.lblShotCompletePrompt.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShotCompletePrompt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShotCompletePrompt.Location = New System.Drawing.Point(56, 72)
        Me.lblShotCompletePrompt.Name = "lblShotCompletePrompt"
        Me.lblShotCompletePrompt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShotCompletePrompt.Size = New System.Drawing.Size(86, 17)
        Me.lblShotCompletePrompt.TabIndex = 8
        Me.lblShotCompletePrompt.Text = "Shot complete"
        '
        'lblShotComplete
        '
        Me.lblShotComplete.BackColor = System.Drawing.SystemColors.Control
        Me.lblShotComplete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblShotComplete.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblShotComplete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShotComplete.Location = New System.Drawing.Point(8, 64)
        Me.lblShotComplete.Name = "lblShotComplete"
        Me.lblShotComplete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblShotComplete.Size = New System.Drawing.Size(33, 33)
        Me.lblShotComplete.TabIndex = 6
        '
        '_optHeadType_3
        '
        Me._optHeadType_3.BackColor = System.Drawing.SystemColors.Control
        Me._optHeadType_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._optHeadType_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optHeadType.SetIndex(Me._optHeadType_3, CType(3, Short))
        Me._optHeadType_3.Location = New System.Drawing.Point(127, 369)
        Me._optHeadType_3.Name = "_optHeadType_3"
        Me._optHeadType_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optHeadType_3.Size = New System.Drawing.Size(129, 25)
        Me._optHeadType_3.TabIndex = 3
        Me._optHeadType_3.TabStop = True
        Me._optHeadType_3.Text = "Mk &9"
        Me._optHeadType_3.UseVisualStyleBackColor = False
        '
        '_optHeadType_2
        '
        Me._optHeadType_2.BackColor = System.Drawing.SystemColors.Control
        Me._optHeadType_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._optHeadType_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optHeadType.SetIndex(Me._optHeadType_2, CType(2, Short))
        Me._optHeadType_2.Location = New System.Drawing.Point(127, 345)
        Me._optHeadType_2.Name = "_optHeadType_2"
        Me._optHeadType_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optHeadType_2.Size = New System.Drawing.Size(129, 25)
        Me._optHeadType_2.TabIndex = 2
        Me._optHeadType_2.TabStop = True
        Me._optHeadType_2.Text = "Mk 7 - Midi / &Ultima"
        Me._optHeadType_2.UseVisualStyleBackColor = False
        '
        '_optHeadType_1
        '
        Me._optHeadType_1.BackColor = System.Drawing.SystemColors.Control
        Me._optHeadType_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._optHeadType_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optHeadType.SetIndex(Me._optHeadType_1, CType(1, Short))
        Me._optHeadType_1.Location = New System.Drawing.Point(127, 321)
        Me._optHeadType_1.Name = "_optHeadType_1"
        Me._optHeadType_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._optHeadType_1.Size = New System.Drawing.Size(129, 25)
        Me._optHeadType_1.TabIndex = 1
        Me._optHeadType_1.TabStop = True
        Me._optHeadType_1.Text = "Mk 7 - &Micro / Mini"
        Me._optHeadType_1.UseVisualStyleBackColor = False
        '
        'frmPrintHeadType
        '
        Me.frmPrintHeadType.BackColor = System.Drawing.SystemColors.Control
        Me.frmPrintHeadType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmPrintHeadType.Location = New System.Drawing.Point(98, 281)
        Me.frmPrintHeadType.Name = "frmPrintHeadType"
        Me.frmPrintHeadType.Padding = New System.Windows.Forms.Padding(0)
        Me.frmPrintHeadType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmPrintHeadType.Size = New System.Drawing.Size(145, 121)
        Me.frmPrintHeadType.TabIndex = 0
        Me.frmPrintHeadType.TabStop = False
        Me.frmPrintHeadType.Text = "Print Head Type"
        '
        'lblScore
        '
        Me.lblScore.BackColor = System.Drawing.SystemColors.Control
        Me.lblScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblScore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblScore.Location = New System.Drawing.Point(356, 423)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblScore.Size = New System.Drawing.Size(43, 33)
        Me.lblScore.TabIndex = 21
        Me.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(279, 439)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Today's score:"
        '
        'lblTicker
        '
        Me.lblTicker.BackColor = System.Drawing.SystemColors.Control
        Me.lblTicker.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTicker.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTicker.Location = New System.Drawing.Point(162, 481)
        Me.lblTicker.Name = "lblTicker"
        Me.lblTicker.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTicker.Size = New System.Drawing.Size(33, 25)
        Me.lblTicker.TabIndex = 19
        Me.lblTicker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(98, 487)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Ticker"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(98, 447)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Cycle (s)"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(98, 423)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Wait (s)"
        '
        'lblHeadDescription
        '
        Me.lblHeadDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblHeadDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHeadDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeadDescription.Location = New System.Drawing.Point(98, 200)
        Me.lblHeadDescription.Name = "lblHeadDescription"
        Me.lblHeadDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHeadDescription.Size = New System.Drawing.Size(315, 73)
        Me.lblHeadDescription.TabIndex = 12
        Me.lblHeadDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'optHeadType
        '
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(166, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(265, 24)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Potting Rig Control - Oracle"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpPanel
        '
        Me.grpPanel.BackgroundImage = CType(resources.GetObject("grpPanel.BackgroundImage"), System.Drawing.Image)
        Me.grpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.grpPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grpPanel.Location = New System.Drawing.Point(14, 27)
        Me.grpPanel.Name = "grpPanel"
        Me.grpPanel.Size = New System.Drawing.Size(114, 47)
        Me.grpPanel.TabIndex = 58
        '
        'btnRePot
        '
        Me.btnRePot.BackColor = System.Drawing.SystemColors.Control
        Me.btnRePot.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRePot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRePot.Location = New System.Drawing.Point(14, 545)
        Me.btnRePot.Name = "btnRePot"
        Me.btnRePot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRePot.Size = New System.Drawing.Size(49, 33)
        Me.btnRePot.TabIndex = 60
        Me.btnRePot.Text = "RePot"
        Me.btnRePot.UseVisualStyleBackColor = False
        '
        'frmMainForm
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(530, 597)
        Me.Controls.Add(Me.btnRePot)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grpPanel)
        Me.Controls.Add(Me.txtCycle)
        Me.Controls.Add(Me.txtWait)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtSerial)
        Me.Controls.Add(Me._optHeadType_0)
        Me.Controls.Add(Me.cmdQuit)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me._optHeadType_3)
        Me.Controls.Add(Me._optHeadType_2)
        Me.Controls.Add(Me._optHeadType_1)
        Me.Controls.Add(Me.frmPrintHeadType)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTicker)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblHeadDescription)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 52)
        Me.MaximizeBox = False
        Me.Name = "frmMainForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Potting Rig Control"
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        CType(Me.optHeadType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpPanel As System.Windows.Forms.Panel
    Public WithEvents btnRePot As Button
#End Region
End Class