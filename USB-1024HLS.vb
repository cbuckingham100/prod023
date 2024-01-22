Option Strict Off
Option Explicit On
Friend Class frmSetBitOut
	Inherits System.Windows.Forms.Form
	'ULDO02.MAK================================================================
	
	' File:                         ULDO02.MAK
	
	' Library Call Demonstrated:    cbDBitOut%()
	
	' Purpose:                      Sets the state of a single digital output bit.
	
	' Demonstration:                Configures FIRSTPORTA for output and writes
	'                               the bit values.
	
	' Other Library Calls:          cbDConfigPort%()
	'                               cbErrHandling%()
	
	' Special Requirements:         Board 0 must have a digital output port.
	
	' (c) Copyright 1995-2002, Measurement Computing Corp.
	' All rights reserved.
	'==========================================================================
	
	'Const BoardNum = 0              ' Board number
	'
	'Const PortNum% = FIRSTPORTA     ' use first digital port
	'Const Direction% = DIGITALOUT   ' program first digital port for output mode
	
	'UPGRADE_WARNING: Event chkSetBit.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkSetBit_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkSetBit.CheckStateChanged
		Dim Index As Short = chkSetBit.GetIndex(eventSender)
		Dim ULStat As Short
		Dim BitValue As Short
		Dim BitNum As Short
		Dim PortType As Short
        'Dim intValue As Short

        PortType = PortNum
		BitNum = Index
		BitValue = chkSetBit(Index).CheckState
		
		If booIOBoardPresent = True Then
			ULStat = cbDBitOut(BoardNum, PortType, BitNum, BitValue)
			If ULStat <> 0 Then Stop
		End If
		
		'   ULStat% = cbDBitIn(BoardNum, PortType%, BitNum%, intValue)
		'   If ULStat% <> 0 Then Stop
		'
		'   MsgBox "Value of " & BitNum% & " is " & intValue
		
	End Sub
	
	Private Sub ReadPortB()
		Dim ULStat As Short
		Dim intValue As Short
		
		If booIOBoardPresent = True Then
			ULStat = cbDIn(BoardNum, FIRSTPORTB, intValue)
			If ULStat <> 0 Then Stop
		End If
		
		MsgBox("Value of Port B is " & intValue)
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Hide()
	End Sub
	
	Private Sub cmdEndProgram_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEndProgram.Click
		Dim ULStat As Short
		Dim DataValue As Short
		
		DataValue = 0
		
		If booIOBoardPresent = True Then
			ULStat = cbDOut(BoardNum, FIRSTPORTC, DataValue)
			If ULStat <> 0 Then Stop
		End If
		
		End
		
	End Sub
	
	Private Sub cmdReadB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdReadB.Click
		ReadPortB()
	End Sub
	
	
	
	Private Sub frmSetBitOut_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' Load stuff happening on MainForm
		'
		'   ' declare revision level of Universal Library
		'
		'   ULStat% = cbDeclareRevision(CURRENTREVNUM)
		'
		'   ' Initiate error handling
		'   '  activating error handling will trap errors like
		'   '  bad channel numbers and non-configured conditions.
		'   '  Parameters:
		'   '    PRINTALL    :all warnings and errors encountered will be printed
		'   '    DONTSTOP    :if an error is encountered, the program will not stop,
		'   '                 errors must be handled locally
		'
		'
		'   ULStat% = cbErrHandling(PRINTALL, DONTSTOP)
		'   If ULStat% <> 0 Then Stop
		'
		'   ' If cbErrHandling% is set for STOPALL or STOPFATAL during the program
		'   ' design stage, Visual Basic will be unloaded when an error is encountered.
		'   ' We suggest trapping errors locally until the program is ready for compiling
		'   ' to avoid losing unsaved data during program design.  This can be done by
		'   ' setting cbErrHandling options as above and checking the value of ULStat%
		'   ' after a call to the library. If it is not equal to 0, an error has occurred.
		'
		'   ' configure FIRSTPORTA for digital output
		'   '  Parameters:
		'   '    BoardNum    :the number used by CB.CFG to describe this board
		'   '    PortNum%    :the output port
		'   '    Direction%  :sets the port for input or output
		'
		'   ULStat% = cbDConfigPort(BoardNum, FIRSTPORTA, DIGITALOUT)
		'   If ULStat% <> 0 Then Stop
		'
		'   ULStat% = cbDConfigPort(BoardNum, FIRSTPORTB, DIGITALIN)
		'   If ULStat% <> 0 Then Stop
		'
		'   ULStat% = cbDConfigPort(BoardNum, FIRSTPORTCL, DIGITALOUT)
		'   If ULStat% <> 0 Then Stop
		'
		'   ULStat% = cbDConfigPort(BoardNum, FIRSTPORTCH, DIGITALOUT)
		'   If ULStat% <> 0 Then Stop
		'
		
		
		
		
		
	End Sub
End Class