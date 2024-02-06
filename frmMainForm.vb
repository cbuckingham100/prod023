Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports log4net
Imports log4net.Config

Friend Class frmMainForm
	Inherits System.Windows.Forms.Form
    Dim conn As New SqlConnection
    Dim ds As New DataSet
    Dim sqlcmd As New SqlCommand

    Dim strConnString As String
	Dim strCmdString As String
	Dim colShowWhileWaiting As Integer
	Dim booOvrMode As Boolean
	Dim intOvrTime As Short
	Dim ULStat As Short
    Private Shared ReadOnly log As ILog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)



    'UPGRADE_WARNING: Event chkOkToDispense.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub chkOkToDispense_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkOkToDispense.CheckStateChanged
        Dim i As Short

        If chkOkToDispense.CheckState = 0 Then
            EnablePrintHeadTypes(True)

            tmrSecTick.Enabled = False
            gblSecTicker = 0
            lblTicker.Text = CStr(gblSecTicker)

            tmrSecTick.Enabled = False
            gblSecTicker = 0


            tmrCheckShotComplete.Enabled = False
            tmrCheckShotCompleteAuto.Enabled = False
            tmrRemoveOkSignal.Enabled = False

            lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colBlank) ' blank
            lblShotCompletePrompt.Text = "Shot cancelled"
            cmdCancel.Enabled = False
            cmdQuit.Enabled = True

            txtSerial.Focus()

            For i = 1 To optHeadType.UBound ' clear head selection
                optHeadType(i).Checked = 0
            Next

            If booIOBoardPresent = True Then
                If booShowDiagMessages = True Then MsgBox("Disable dispense")
                ULStat = cbDOut(BoardNum, FIRSTPORTC, CONTROLRESET)
                If ULStat <> 0 Then Stop
                ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
                If ULStat <> 0 Then Stop
            End If

        Else
            SetShotSize()
            lblHeadDescription.Text = "Manual control"
            If booIOBoardPresent = True Then
                If booShowDiagMessages = True Then MsgBox("Enable dispense")
                ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 1) ' enable to dispense
                If ULStat <> 0 Then Stop
            End If

            EnablePrintHeadTypes(False)

            tmrSecTick.Enabled = True
            gblSecTicker = 0

            'UPGRADE_WARNING: Timer property tmrRemoveOkSignal.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'
            tmrRemoveOkSignal.Interval = gblWaitForSuccess - gblRigCycleTime
            tmrRemoveOkSignal.Enabled = True

            colShowWhileWaiting = colWaiting
            'UPGRADE_WARNING: Timer property tmrCheckShotComplete.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'
            tmrCheckShotComplete.Interval = FlashInterval
            tmrCheckShotComplete.Enabled = True

            cmdCancel.Enabled = True
            cmdQuit.Enabled = False
        End If
    End Sub
	
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        ResetForm()

        '    EnablePrintHeadTypes True
        '
        '    chkOkToDispense.Value = 0

        chkOkToDispense_CheckStateChanged(chkOkToDispense, New System.EventArgs())

        '    lblShotComplete.BackColor = colBlank ' blank
        '    lblShotCompletePrompt = "Shot cancelled"
        '    lblHeadDescription = "Shot cancelled"

    End Sub
	
    Private Sub cmdQuit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdQuit.Click
        Dim DataValue As Short

        DataValue = 0

        txtSerial.Text = ""

        If booIOBoardPresent = True Then
            ULStat = cbDOut(BoardNum, FIRSTPORTA, DataValue)
            If ULStat <> 0 Then Stop

            ULStat = cbDOut(BoardNum, FIRSTPORTC, CONTROLRESET)
            If ULStat <> 0 Then Stop
        End If

        End

    End Sub
	
    Private Sub cmdSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSave.Click

        ' Disabled in 3.5
        ' cmdWait and cmdCycle now disabled, and cmdSave not visible

        'gblWaitSecs = CInt(txtWait.Text)
        'gblWaitForSuccess = gblWaitSecs * 1000

        'gblRigCycleSecs = CInt(txtCycle.Text)
        'gblRigCycleTime = gblRigCycleSecs * 1000

        'MsgBox("Timings saved for this session only - to set them as defaults" & vbCrLf & "set shortcut arguments to /WAIT:" & gblWaitSecs & " /CYCLE:" & gblRigCycleSecs)

    End Sub
	
	'UPGRADE_WARNING: Form event frmMainForm.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmMainForm_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		txtSerial.Focus()
	End Sub
	
	Private Sub frmMainForm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        XmlConfigurator.Configure()
        booIOBoardPresent = True

        ' declare revision level of Universal Library

        Me.Text = "PROD023 - Potting Rig v" & gblVersion
		
		Dim gINIFILE As String
		
		Dim sAppName As String
		sAppName = "PROD023"
		
		gINIFILE = My.Application.Info.DirectoryPath & "\LINXVB_ORACLE.INI"
		Sleep(5000)
		
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(gINIFILE) = "" Then
            MsgBox("Unable to find config file " & vbCrLf & gINIFILE)
            log.Error("Unable to find config file " & vbCrLf & gINIFILE)
            End
		End If
		
		
		Dim gServer As String
		
		Dim ireturn As Short
		Dim sstringspace As String
		sstringspace = Space(128)
		
		ireturn = GetPrivateProfileStringKeys(sAppName, "Server", "", sstringspace, Len(sstringspace), gINIFILE)
		
		If ireturn > 0 Then
            gServer = VB.Left(sstringspace, ireturn)
            log.Debug("gServer: " + gServer)
        Else
			gServer = ""
            MsgBox("Fatal error: " & sAppName & " 'Server' not found in " & gINIFILE, MsgBoxStyle.Critical, sAppName)
            log.Error(sAppName & " 'Server' not found in " & gINIFILE)
            End
		End If
		
		ireturn = GetPrivateProfileStringKeys(sAppName, "Boardnum", "", sstringspace, Len(sstringspace), gINIFILE)
		
		If ireturn > 0 Then
            BoardNum = CShort(VB.Left(sstringspace, ireturn))
            log.Debug("BoardNum: " + BoardNum.ToString())
        Else
			BoardNum = 0
            MsgBox("Fatal error: " & sAppName & " 'Boardnum' not found in " & gINIFILE, MsgBoxStyle.Critical, sAppName)
            log.Error(sAppName & " 'Boardnum' not found in " & gINIFILE)
            End
		End If

        strConnString = "Server=" & gServer & ";Database=linxmaster;User Id=oracle_lm;Password=tcl925K!"
        log.Debug("strConnString: " + strConnString)
        conn.ConnectionString = strConnString
        conn.Open()


        If VB.Command() <> "" Then
			If InStr(VB.Command(), "/WAIT") > 0 Then
				gblWaitSecs = CInt(Mid(VB.Command(), InStr(VB.Command(), "/WAIT") + 6, 3))
			End If
			
			If InStr(VB.Command(), "/CYCLE") > 0 Then
				gblRigCycleSecs = CInt(Mid(VB.Command(), InStr(VB.Command(), "/CYCLE") + 7, 3))
			End If
			
		End If
		
		If gblWaitSecs = 0 Then
            gblWaitSecs = gblWaitForSuccessDefault
            'MsgBox("'/WAIT' parameter missing, now defaulted to " & gblWaitSecs & " seconds")
        End If
		
		If gblRigCycleSecs = 0 Then
			gblRigCycleSecs = gblRigCycleTimeDefault
            'MsgBox("'/CYCLE' parameter missing, now defaulted to " & gblRigCycleSecs & " seconds")
        End If
		
		gblRigCycleTime = gblRigCycleSecs * 1000
		txtCycle.Text = CStr(gblRigCycleSecs)
		
		gblWaitForSuccess = gblWaitSecs * 1000
		txtWait.Text = CStr(gblWaitSecs)
		
		
		ULStat = cbDeclareRevision(CURRENTREVNUM)
        log.Debug("ULStat: " + ULStat.ToString())

        ' Initiate error handling
        '  activating error handling will trap errors like
        '  bad channel numbers and non-configured conditions.
        '  Parameters:
        '    PRINTALL    :all warnings and errors encountered will be printed
        '    DONTSTOP    :if an error is encountered, the program will not stop,
        '                 errors must be handled locally


        ULStat = cbErrHandling(PRINTALL, DONTSTOP)
        log.Debug("ULStat: " + ULStat.ToString())
        If ULStat <> 0 Then Stop
		
		' If cbErrHandling% is set for STOPALL or STOPFATAL during the program
		' design stage, Visual Basic will be unloaded when an error is encountered.
		' We suggest trapping errors locally until the program is ready for compiling
		' to avoid losing unsaved data during program design.  This can be done by
		' setting cbErrHandling options as above and checking the value of ULStat%
		' after a call to the library. If it is not equal to 0, an error has occurred.
		
		' configure FIRSTPORTA for digital output
		'  Parameters:
		'    BoardNum    :the number used by CB.CFG to describe this board
		'    PortNum%    :the output port
		'    Direction%  :sets the port for input or output
		
		If booIOBoardPresent = True Then
			ULStat = cbDConfigPort(BoardNum, FIRSTPORTA, DIGITALOUT)
			If ULStat <> 0 Then
				If MsgBox("Looks like IO board missing." & vbCrLf & "Do you want to continue without IO ?", MsgBoxStyle.YesNo, "IO Error condition") = MsgBoxResult.Yes Then
					booIOBoardPresent = False
					MsgBox("IO Board Absent." & vbCrLf & "You must restart this program before IO will work.")
				Else
					End
				End If
			End If
		End If
		
		If booIOBoardPresent = True Then
            ULStat = cbDConfigPort(BoardNum, FIRSTPORTB, DIGITALIN)
            If ULStat <> 0 Then Stop

            ULStat = cbDConfigPort(BoardNum, FIRSTPORTCL, DIGITALOUT)
            If ULStat <> 0 Then Stop

            ULStat = cbDConfigPort(BoardNum, FIRSTPORTCH, DIGITALOUT)
            If ULStat <> 0 Then Stop

            ULStat = cbDOut(BoardNum, FIRSTPORTA, 0)
            If ULStat <> 0 Then Stop

            ULStat = cbDOut(BoardNum, FIRSTPORTC, CONTROLRESET)
            If ULStat <> 0 Then Stop
        End If
		
		ResetForm()
		
		On Error GoTo OpenError

        '    MsgBox ScreenResolution(Me)
        Me.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height) - 1000)
		Me.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width) - 1000)
		
		gblSecTicker = 0
		lblTicker.Text = CStr(gblSecTicker)
		
		
		lblScore.Text = CStr(CountTodayStartRecords())
		On Error GoTo 0
        Me.CenterToScreen()


        Exit Sub
		
OpenError:
        MsgBox("Unable to access linxmaster database using -" & vbCrLf & strConnString, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error")
        log.Error("Unable to access linxmaster database using -" & vbCrLf & strConnString)
        End
		
	End Sub
	
	Sub ResetForm()
		Dim i As Short
        For i = 1 To 3
            optHeadType(i).Checked = False
        Next i

        txtSerial.Text = ""
		cmdCancel.Enabled = False
		cmdQuit.Enabled = True
		
		chkOkToDispense.CheckState = System.Windows.Forms.CheckState.Unchecked
        chkOkToDispense.Enabled = True

        lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colBlank) ' blank
		lblShotCompletePrompt.Text = "Shot complete?"
		
		
		tmrSecTick.Enabled = False
		gblSecTicker = 0
		
		tmrSecTickAuto.Enabled = False
		gblSecTickerAuto = 0
		
		tmrRemoveOkSignal.Enabled = False
		tmrOvrCountDown.Enabled = False
		
		tmrCheckShotCompleteAuto.Enabled = False
		tmrCheckShotComplete.Enabled = False
		
        'lblScore.Text = CStr(CountTodayStartRecords())
		
	End Sub
	
	Sub EnablePrintHeadTypes(ByRef booState As Boolean)
		Dim i As Short

        For i = 1 To 3
            optHeadType(i).Enabled = booState
        Next i

        frmPrintHeadType.Enabled = booState
		
	End Sub
	
	Private Sub frmMainForm_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		If UnloadMode = System.Windows.Forms.CloseReason.UserClosing Then Cancel = True
		eventArgs.Cancel = Cancel
	End Sub
	
	Public Sub mnuBitTest_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBitTest.Click
		If booIOBoardPresent = True Then
			frmSetBitOut.Show()
		Else
			MsgBox("Sorry, IO diagnostic only available when IO board connected", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, "No IO ....")
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optHeadType.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optHeadType_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optHeadType.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optHeadType.GetIndex(eventSender)
			chkOkToDispense.Enabled = True
			lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colBlank) ' blank
			lblShotCompletePrompt.Text = "Shot complete?"
			lblHeadDescription.Text = ""
			SetShotSize()
		End If
	End Sub
	
	Private Sub tmrCheckShotComplete_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrCheckShotComplete.Tick
		Dim intValue As Short
        XmlConfigurator.Configure()
        log.Debug("Function Name: tmrCheckShotComplete_Tick")
        If booIOBoardPresent = True Then
            log.Debug(" --Output from the PCB -- ")
            ULStat = cbDIn(BoardNum, FIRSTPORTB, intValue)
            log.Debug("BoardNum: " + BoardNum.ToString())
            log.Debug("FIRSTPORTB: " + FIRSTPORTB.ToString())
            log.Debug("intValue: " + intValue.ToString())
            log.Debug("ULStat: " + ULStat.ToString())
            If ULStat <> 0 Then Stop
        Else
            intValue = 0
		End If
		
		If booShowDiagMessages = True Then
			MsgBox("Value of Port B is " & intValue)
		End If
		
		If intValue <> 0 Then
			EnablePrintHeadTypes(True)
			ResetForm()
			lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colSuccess) ' green
			lblShotCompletePrompt.Text = "Shot success"
			lblHeadDescription.Text = "Last success - Manual shot" & vbCrLf & "at " & Now
			cmdCancel.Enabled = False
			cmdQuit.Enabled = True
			
			If booIOBoardPresent = True Then
                ULStat = cbDOut(BoardNum, FIRSTPORTC, CONTROLRESET)
                log.Debug(" --- CONTROL RESET START --- ")
                log.Debug("BoardNum: " + BoardNum.ToString())
                log.Debug("FIRSTPORTB: " + FIRSTPORTB.ToString())
                log.Debug("intValue: " + intValue.ToString())
                log.Debug("ULStat: " + ULStat.ToString())
                log.Debug(" --- CONTROL RESET END --- ")
                ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
                log.Debug(" --- Disable to dispense --- ")
                log.Debug("BoardNum: " + BoardNum.ToString())
                log.Debug("FIRSTPORTB: " + FIRSTPORTB.ToString())
                log.Debug("intValue: " + intValue.ToString())
                log.Debug("ULStat: " + ULStat.ToString())
                log.Debug(" --- Disable to dispense END --- ")
            End If
			
			Exit Sub
		End If
		
		ChangelblShotComplete()
		
	End Sub
	
	Private Sub tmrCheckShotCompleteAuto_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrCheckShotCompleteAuto.Tick
        Dim intValue As Short

        XmlConfigurator.Configure()
        log.Debug("Function Name: tmrCheckShotCompleteAuto_Tick")
        If booIOBoardPresent = True Then
            log.Debug(" --Output from the PCB -- ")
            ULStat = cbDIn(BoardNum, FIRSTPORTB, intValue)
            log.Debug("BoardNum: " + BoardNum.ToString())
            log.Debug("FIRSTPORTB: " + FIRSTPORTB.ToString())
            log.Debug("intValue: " + intValue.ToString())
            log.Debug("ULStat: " + ULStat.ToString())
            If ULStat <> 0 Then Stop
        Else
            intValue = 0
		End If
		
		If booShowDiagMessages = True Then
			MsgBox("Value of Port B is " & intValue)
		End If
		
		If intValue <> 0 Then

            ' What we need is
            '   success -
            '       Green background
            '           clearing on 30 sec timer?
            '       Record potting success
            log.Debug("Output from the PCB : Success Shot fired")
            If UpdateRecordAfterPotting((txtSerial.Text)) <> "OK" Then
				MsgBox("Unable to record successful potting for - " & txtSerial.Text & vbCrLf & "Please inform supervision / Business System", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "Success Log Failure")
			End If
			
			lblHeadDescription.Text = "Last success - " & vbCrLf & txtSerial.Text & " " & Now
			
			EnablePrintHeadTypes(True)
			ResetForm()
			lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colSuccess) ' green
			lblShotCompletePrompt.Text = "Shot success"
			cmdCancel.Enabled = False
			cmdQuit.Enabled = True
			txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colTxtBox)
			txtSerial.Focus()
			
			If booIOBoardPresent = True Then
                ULStat = cbDOut(BoardNum, FIRSTPORTC, CONTROLRESET)
                log.Debug(" --- CONTROL RESET START --- ")
                log.Debug("BoardNum: " + BoardNum.ToString())
                log.Debug("FIRSTPORTB: " + FIRSTPORTB.ToString())
                log.Debug("intValue: " + intValue.ToString())
                log.Debug("ULStat: " + ULStat.ToString())
                log.Debug(" --- CONTROL RESET END --- ")
                ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
                log.Debug(" --- Disable to dispense --- ")
                log.Debug("BoardNum: " + BoardNum.ToString())
                log.Debug("FIRSTPORTB: " + FIRSTPORTB.ToString())
                log.Debug("intValue: " + intValue.ToString())
                log.Debug("ULStat: " + ULStat.ToString())
                log.Debug(" --- Disable to dispense END --- ")
            End If
			
			tmrCheckShotCompleteAuto.Enabled = False
			
			Exit Sub
		End If
		
		ChangelblShotComplete()
		
	End Sub
	
	Sub ChangelblShotComplete()
		If System.Drawing.ColorTranslator.ToOle(lblShotComplete.BackColor) <> colBlank Then
			lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colBlank) ' blank
		Else
			lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colShowWhileWaiting) ' yellow/orange
			lblShotCompletePrompt.Text = "Shot waiting"
		End If
	End Sub
	
	
	
	Sub SetShotSize()
		Dim intShotDemand As Short

        If booIOBoardPresent = True Then
            ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
        End If

        ' Reset rig
        Wait(2)

        ' NB note rig is expecting different values to shot size given in database

        If optHeadType(1).Checked = True Then
            intShotDemand = 1
        ElseIf optHeadType(2).Checked = True Then
            intShotDemand = 1 ' was 2 or 3
        ElseIf optHeadType(3).Checked = True Then
            intShotDemand = 4
        Else
            MsgBox("Undefined pot size", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Potting Shot Size")
        End If

        If booIOBoardPresent = True Then
            ULStat = cbDOut(BoardNum, FIRSTPORTC, intShotDemand)
        End If

        ' Allow rig to accept configuration

        Wait(2)

    End Sub
	
	Private Sub tmrOvrCountDown_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrOvrCountDown.Tick
		intOvrTime = intOvrTime - 1
		If intOvrTime = 0 Then
			tmrOvrCountDown.Enabled = False
			txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colTxtBox)
			txtSerial.Text = ""
			lblHeadDescription.Text = ""
		Else
			txtSerial.Text = "." & intOvrTime
			txtSerial.Focus()
		End If
	End Sub
	
	Private Sub tmrRemoveOkSignal_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrRemoveOkSignal.Tick
		
		If booShowDiagMessages = True Then MsgBox("Disable dispense")
		
		colShowWhileWaiting = colAlert
		tmrRemoveOkSignal.Enabled = False
		
		If booIOBoardPresent = True Then
			ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
		End If
		
	End Sub
	
	Private Sub tmrSecTick_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrSecTick.Tick
		
		gblSecTicker = gblSecTicker + 1
		lblTicker.Text = CStr(gblSecTicker)
		
		If gblSecTicker > gblWaitSecs Then
			
			EnablePrintHeadTypes(True)
			ResetForm()
			lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colFail) ' red
			lblShotCompletePrompt.Text = "Shot failed!"
			lblHeadDescription.Text = "Last event - Manual shot" & vbCrLf & "failed at " & Now
			
			If booIOBoardPresent = True Then
				ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
			End If
			
			tmrSecTick.Enabled = False
			
		End If
		
		
	End Sub
	
	
	Private Sub tmrSecTickAuto_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrSecTickAuto.Tick
		
		gblSecTickerAuto = gblSecTickerAuto + 1
		lblTicker.Text = CStr(gblSecTickerAuto)
		
		If gblSecTickerAuto > gblWaitSecs Then
			'   time out -
			'       Red background to input box
			'       Warning message (manual/auto clear ??)
			'       Do we log failed pot attempt/
			'       Return to input box
			
			EnablePrintHeadTypes(True)
			lblHeadDescription.Text = "Last event - " & txtSerial.Text & vbCrLf & " shot failed at " & Now
			ResetForm()
			lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colFail) ' red
			lblShotCompletePrompt.Text = "Shot failed!"
			txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colTxtBox)
			txtSerial.Focus()
			
			If booIOBoardPresent = True Then
				ULStat = cbDOut(BoardNum, FIRSTPORTC, CONTROLRESET)
				ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
			End If
			
			tmrSecTickAuto.Enabled = False
			
		End If
		
		
	End Sub
	
    Private Sub txtSerial_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSerial.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii >= 97 And KeyAscii <= 122 Then ' force capitals
            KeyAscii = KeyAscii - 32
        End If

        txtSerial.Text = Trim(txtSerial.Text)

        lblHeadDescription.Text = ""
        lblShotComplete.BackColor = System.Drawing.ColorTranslator.FromOle(colBlank) ' blank
        lblShotCompletePrompt.Text = "Shot complete?"

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtSerial_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtSerial.Validating

    End Sub

    Private Function CheckRecentStartRecord(ByRef strSerialNo As String) As RecentStartEnquiry
        Dim strSelect As String
        Dim Dt As DataTable
        Dim objCheckRecentStartRecord As New RecentStartEnquiry

        strSelect = "SELECT isnull(rs.[unique_id],'') [unique_id] " &
                ",rs.[product] " &
                ",rs.[serial] " &
                ",isnull(rs.[step3],'')[step3] " &
                ",isnull(rs.[potting_success],'')[potting_success] " &
                ",isnull(ht.full_description,'') [full_description] " &
                ",isnull(ht.potting_shot,'') [potting_shot] " &
                ",isnull(rs.scrapped,'') [scrapped] " &
                "FROM [linxmaster].[dbo].[PrintheadRecentStarts] as rs with (nolock) " &
                "left outer join [linxmaster].[dbo].[rh33Head_type] as ht with (nolock) " &
                "on left(rs.product,7) = left(ht.AS_part_no,7) " &
                "WHERE (serial = '" & Trim(strSerialNo) & "')"

        Using cmd As New SqlCommand With {.Connection = conn, .CommandText = strSelect}
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dt = New DataTable
                Dt.Load(cmd.ExecuteReader)
            Catch ex As Exception
                Throw (New Exception(ex.Message))
            End Try
        End Using

        If Dt.Rows.Count = 0 Then
            objCheckRecentStartRecord.strSerial = ""
        Else
            objCheckRecentStartRecord.strUniqueId = Dt.Rows(0)("unique_id").ToString()
            objCheckRecentStartRecord.strProduct = Dt.Rows(0)("product").ToString()
            objCheckRecentStartRecord.strSerial = Dt.Rows(0)("serial").ToString()
            objCheckRecentStartRecord.datStep3 = Dt.Rows(0)("step3").ToString()
            objCheckRecentStartRecord.strPottingSuccess = Dt.Rows(0)("potting_success").ToString()
            objCheckRecentStartRecord.strFullDescription = Dt.Rows(0)("full_description").ToString()
            objCheckRecentStartRecord.strPottingShot = Dt.Rows(0)("potting_shot").ToString()
            objCheckRecentStartRecord.strScrapped = Dt.Rows(0)("scrapped").ToString()

        End If
        Return objCheckRecentStartRecord
    End Function


    Private Function CountTodayStartRecords() As Short
        Dim strSelect As String
        Dim Dt As DataTable
        Dim retCountTodayStartRecords As String = ""

        retCountTodayStartRecords = 0


        strSelect = "SELECT COUNT(1) as counter FROM [linxmaster].[dbo].[PrintheadRecentStarts] as rs with (nolock) " &
                "left outer join [linxmaster].[dbo].[rh33Head_type] as ht with (nolock) " &
                "on left(rs.product,7) = left(ht.AS_part_no,7) " &
                "Where (CONVERT(Char(10), rs.[start_time], 126) = CONVERT(Char(10), GETDATE(), 126))"

        Using cmd As New SqlCommand With {.Connection = conn, .CommandText = strSelect}
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dt = New DataTable
                Dt.Load(cmd.ExecuteReader)
            Catch ex As Exception
                Throw (New Exception(ex.Message))
            End Try
        End Using

        If Dt.Rows.Count > 0 Then
            retCountTodayStartRecords = Dt.Rows(0)("counter").ToString()
        End If
        Return retCountTodayStartRecords
    End Function


    Private Function UpdateRecordBeforePotting(ByRef strSerialNo As String) As String
		Dim strUpdate As String
        Dim retUpdateRecordBeforePotting As String = ""
        strUpdate = "UPDATE dbo.PrintheadRecentStarts " &
                "SET step3 = getdate() " &
                "WHERE serial = '" & Trim(strSerialNo) & "'"

        Using cmd As New SqlCommand With {.Connection = conn, .CommandText = strUpdate}
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                cmd.ExecuteNonQuery()
                retUpdateRecordBeforePotting = "OK"
            Catch ex As Exception
                retUpdateRecordBeforePotting = "FAIL"
                MsgBox(ex.Message)
                Throw (New Exception(ex.Message))
            End Try
        End Using
        Return retUpdateRecordBeforePotting
    End Function


    Private Function UpdateRecordRePot(ByRef strSerialNo As String) As String
        Dim strUpdate As String
        Dim retUpdateRecordBeforePotting As String = ""
        strUpdate = "UPDATE dbo.PrintheadRecentStarts " &
                "SET step3 = NULL,potting_success='' " &
                "WHERE serial = '" & Trim(strSerialNo) & "'"

        Using cmd As New SqlCommand With {.Connection = conn, .CommandText = strUpdate}
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                cmd.ExecuteNonQuery()
                retUpdateRecordBeforePotting = "OK"
            Catch ex As Exception
                retUpdateRecordBeforePotting = "FAIL"
                MsgBox(ex.Message)
                Throw (New Exception(ex.Message))
            End Try
        End Using
        Return retUpdateRecordBeforePotting
    End Function


    Private Function UpdateRecordAfterPotting(ByRef strSerialNo As String) As String
        Dim strUpdate As String
        Dim strMessage As String
        Dim retUpdateRecordAfterPotting As String = ""

        If booOvrMode = False Then
            strMessage = "YES"
        Else
            strMessage = "OVR"
        End If

        strUpdate = "UPDATE dbo.PrintheadRecentStarts " &
                "SET potting_success = '" & VB.Left(strMessage, 3) & "', " &
                "    step3 = getdate() " &
                "WHERE serial = '" & Trim(strSerialNo) & "'"
        Using cmd As New SqlCommand With {.Connection = conn, .CommandText = strUpdate}
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                cmd.ExecuteNonQuery()
                retUpdateRecordAfterPotting = "OK"
            Catch ex As Exception
                retUpdateRecordAfterPotting = "FAIL"
                MsgBox(ex.Message)
                Throw (New Exception(ex.Message))
            End Try
        End Using
        Return retUpdateRecordAfterPotting
    End Function

    Private Sub txtSerial_TextChanged(sender As Object, e As EventArgs) Handles txtSerial.TextChanged

        Try



            If (Trim(txtSerial.Text.Length) = 8) Then
                Dim typRecentStartEnquiry As RecentStartEnquiry

                txtSerial.Text = Trim(txtSerial.Text)

                booOvrMode = False

                'If txtSerial.Text = "" Then
                '    Exit Sub
                'End If

                'If txtSerial.Text = "OVR" Then
                '    lblHeadDescription.Text = "OVR Mode Countdown"
                '    txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colAlert)
                '    intOvrTime = 20
                '    tmrOvrCountDown.Interval = 1000
                '    tmrOvrCountDown.Enabled = True
                '    Exit Sub
                'End If

                'If InStr(txtSerial.Text, ".") > 0 Then ' we are in OVR mode
                '    txtSerial.Text = VB.Left(txtSerial.Text, InStr(txtSerial.Text, ".") - 1)
                '    txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colTxtBox)
                '    booOvrMode = True
                '    tmrOvrCountDown.Enabled = False
                'End If

                ' Restricted serial
                If txtSerial.Text Like "[A-Z][A-Z0-9]######" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object typRecentStartEnquiry. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    typRecentStartEnquiry = CheckRecentStartRecord((txtSerial.Text))

                    '2018/03/07 - sb - added ability to get a Mk9 sized pot with a re-usable code
                    '2019/10/01 - sb - if was "=" now "like"
                    If txtSerial.Text Like "ZZ999999" Then ' special cases to get rig sample
                        typRecentStartEnquiry.datStep3 = CDate("1900-01-01") ' so that it behaves as a first time
                        typRecentStartEnquiry.strPottingSuccess = ""
                        txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colSample) ' make it blue
                    End If

                    If typRecentStartEnquiry.strSerial <> "" Then
                        lblHeadDescription.Text = typRecentStartEnquiry.strFullDescription

                        ' has head been scrapped before?
                        If typRecentStartEnquiry.strScrapped <> "" Then
                            '   yes - msgbox saying head already potted
                            If booOvrMode = False Then ' drop out
                                MsgBox("Head previously rejected!" & vbCrLf & "Inform supervision.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Inform supervision !!")
                                Exit Sub
                            Else
                                MsgBox("Head previously rejected!" & vbCrLf & "But Supervision OVERRIDE activated.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Supervision Override !!")
                            End If
                        End If
                        ' has head been potted before?
                        If typRecentStartEnquiry.strPottingSuccess <> "" Then
                            '   yes - msgbox saying head already potted
                            If booOvrMode = False Then ' drop out
                                MsgBox("Head already potted on " & typRecentStartEnquiry.datStep3 & "!" & vbCrLf & vbCrLf & "Inform supervision.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Inform supervsion !!")
                                Exit Sub
                            Else
                                MsgBox("Head apparently previously potted!" & vbCrLf & vbCrLf & "But Supervision OVERRIDE activated.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Supervision Override !!")
                            End If
                        End If

                        ' has card been scanned before?
                        If typRecentStartEnquiry.datStep3 <> CDate("1900-01-01") And booOvrMode = False Then
                            '   yes - display status message that this is a re-scan
                            MsgBox("Head scanned at ""Potting"" on " & typRecentStartEnquiry.datStep3 & vbCrLf & "but potting did not seem to complete." & vbCrLf & vbCrLf & "Process continuing....", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Head has been scanned before ...")
                        End If
                        ' do we recognise head type?
                        If typRecentStartEnquiry.strProduct = "" Then
                            '   no - msgbox saying we don't recognise
                            MsgBox("Head not recognised." & typRecentStartEnquiry.datStep3 & "!" & vbCrLf & "Inform supervision.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Inform supervsion !!")
                            Exit Sub
                        End If
                        ' have we got a potting spec returned
                        If typRecentStartEnquiry.strPottingShot = "" Then
                            '   no - message box saying head ASxxxxx found but no potting spec listed
                            MsgBox("Potting size for " & typRecentStartEnquiry.strProduct & " - " & typRecentStartEnquiry.strFullDescription & " not in database!" & "Inform supervision.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Inform supervsion !!")
                            Exit Sub
                        End If
                        ' record scan
                        If UpdateRecordBeforePotting((txtSerial.Text)) <> "OK" Then
                            MsgBox("Unable to record scan at potting for - " & txtSerial.Text & vbCrLf & "Please inform supervision / Business System", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Success Log Failure")
                        End If

                        ' display serial in normal text box

                        ' set and enable rig for potting
                        Select Case Trim(typRecentStartEnquiry.strPottingShot)

                            ' Mk 7
                            Case "2"
                                optHeadType(1).Checked = True

                            ' Mk 7 M
                            Case "3"
                                optHeadType(2).Checked = True

                            ' Mk 9 / 11
                            Case "4"
                                optHeadType(3).Checked = True

                            Case Else
                                MsgBox("Potting shot - " & typRecentStartEnquiry.strPottingShot & " - Not recognised" & vbCrLf & "Inform supervision.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Inform supervision !!")
                                Exit Sub
                        End Select

                        Application.DoEvents()

                        '  v3.5 - stop text being highlighted
                        txtSerial.Focus()
                        txtSerial.Select(txtSerial.Text.Length, 0)

                        ' wait for success / time out
                        SetShotSize()

                        If booIOBoardPresent = True Then
                            If booShowDiagMessages = True Then MsgBox("Enable dispense")
                            ' Disabled currently as the hardware proceeds to dispense automatically.
                            ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 1) ' enable to dispense
                        End If

                        EnablePrintHeadTypes(False)

                        tmrSecTickAuto.Enabled = True
                        gblSecTickerAuto = 0

                        lblTicker.Text = CStr(gblSecTickerAuto)

                        colShowWhileWaiting = colWaiting

                        'UPGRADE_WARNING: Timer property tmrCheckShotCompleteAuto.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'
                        tmrCheckShotCompleteAuto.Interval = FlashInterval
                        tmrCheckShotCompleteAuto.Enabled = True

                        'UPGRADE_WARNING: Timer property tmrRemoveOkSignal.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'
                        tmrRemoveOkSignal.Interval = gblWaitForSuccess - gblRigCycleTime
                        tmrRemoveOkSignal.Enabled = True

                        cmdCancel.Enabled = True
                        cmdQuit.Enabled = False
                        chkOkToDispense.Enabled = False
                        ''txtSerial.BackColor = colTxtBox

                        '   success - handled in tmrCheckShotCompleteAuto

                    Else
                        txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colFail) ' Red
                        txtSerial.Focus()
                        lblHeadDescription.Text = ""
                        MsgBox("No PrintheadRecentStart record" & vbCrLf & "found matching this serial.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Cannot continue ....")
                        txtSerial.BackColor = System.Drawing.ColorTranslator.FromOle(colTxtBox) ' normal
                        txtSerial.Text = ""
                        txtSerial.Focus()
                    End If

                End If
            End If

        Catch ex As Exception

            MsgBox("Unable to process potting, error:" & ex.Message)


        End Try



    End Sub


    Private Sub btnRePot_Click(sender As Object, e As EventArgs) Handles btnRePot.Click

        If txtSerial.Text <> "" Then

            Dim result As DialogResult = MessageBox.Show("About to clear potting record for printhead " & txtSerial.Text & vbCrLf & vbCrLf & "Are you sure?", "Potting Rig", MessageBoxButtons.OKCancel)
            If result = DialogResult.Cancel Then Exit Sub

            UpdateRecordRePot(txtSerial.Text)

            MsgBox(txtSerial.Text & " is cleared and can now be repotted")
            txtSerial.Text = ""
        End If



    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

        Dim intShotDemand As Short

        If booIOBoardPresent = True Then
            ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 0) ' disable to dispense
        End If

        Wait(2)

        If txtTest.Text = "" Then
            MsgBox("Undefined pot size", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Test")
            Exit Sub
        End If

        intShotDemand = CInt(txtTest.Text)

        If booIOBoardPresent = True Then
            ULStat = cbDOut(BoardNum, FIRSTPORTC, intShotDemand)
        End If

        Wait(2)

        If booIOBoardPresent = True Then
            ULStat = cbDBitOut(BoardNum, FIRSTPORTA, 0, 1) ' enable to dispense
        End If
        EnablePrintHeadTypes(False)

        tmrSecTickAuto.Enabled = True
        gblSecTickerAuto = 0

        lblTicker.Text = CStr(gblSecTickerAuto)

        colShowWhileWaiting = colWaiting

        tmrCheckShotCompleteAuto.Interval = FlashInterval
        tmrCheckShotCompleteAuto.Enabled = True

        tmrRemoveOkSignal.Interval = gblWaitForSuccess - gblRigCycleTime
        tmrRemoveOkSignal.Enabled = True

        cmdCancel.Enabled = True
        cmdQuit.Enabled = False
        chkOkToDispense.Enabled = False

    End Sub

    Private Sub Wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub






End Class