Option Strict Off
Option Explicit On
Module Module1

    ' 2024/01/19    CB  v3.5    Disable Wait and Cycle, text highlighting
    ' 2024/01/31    CB  v3.6    Align shot size to new rig expectations
    ' 2024/01/31    CB  v3.7    dispense retriggered
    ' 2024/02/06    CB  v3.8    Install shot size test + change value sent to rig

    Public Const gblVersion As String = "3.8"


    Declare Function GetPrivateProfileStringByKeyName Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal lpszSection As String, ByVal lpszKey As String, ByVal lpszDefault As String, ByVal lpszReturnBuffer As String, ByVal cchReturnBuffer As Integer, ByVal lpszFile As String) As Integer
	
	Declare Function GetPrivateProfileStringKeys Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal lpszSection As String, ByVal lpszKey As String, ByVal lpszDefault As String, ByVal lpszReturnBuffer As String, ByVal cchReturnBuffer As Integer, ByVal lpszFile As String) As Integer
	
	Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
	
	'2018/03/07 - sb - added ability to get a Mk9 sized pot
	
	Public Const CONTROLRESET As Short = 255
	
	Public booIOBoardPresent As Boolean
	
	''Global Const BoardNum = 0             ' Board number
	
	Public Const PortNum As Short = FIRSTPORTA ' use first digital port
    Public Const Direction As Short = DIGITALOUT ' program first digital port for output mode

    ' 2018/03/06 - sb - Global Const gblWaitForSuccess As Long = 45000    ' how long to wait for a success from potting
    ' 2018/10/11 - CB - Global Const gblWaitForSuccess As Long = 50000    ' how long to wait for a success from potting
    ' 2019/02/26 - CB - Global Const gblWaitForSuccess As Long = 60000    ' how long to wait for a success from potting

    Public Const gblWaitForSuccessDefault As Integer = 75 ' seconds
	Public gblWaitSecs As Integer ' how long to wait for a success from potting, fetched from command line
	Public gblWaitForSuccess As Integer
	
	Public gblSecTicker As Short
	Public gblSecTickerAuto As Short
	
	Public BoardNum As Short ' Board number
	
	
	Public Const gblRigCycleTimeDefault As Integer = 15 ' seconds
	Public gblRigCycleSecs As Integer
	Public gblRigCycleTime As Integer ' how long to allow for Potting Rig to cycle
	
	''Global Const gblWaitForSuccess As Long = 64000    ' how long to wait for a success from potting
	''Global Const gblRigCycleTime As Long = 25000      ' how long to allow for Potting Rig to cycle
	
	Public Const FlashInterval As Integer = 1000 ' flash interval
	Public Const booShowDiagMessages As Boolean = False ' see diagnostic message boxes
	
	Public Const colBlank As Integer = &H8000000F ' normal background
	Public Const colSuccess As Integer = &HFF00 ' Normally green
	Public Const colWaiting As Integer = &HFFFF ' Normally yellow
	Public Const colAlert As Integer = &H80FF ' normally orange
	Public Const colFail As Integer = &HFF ' normally red
	Public Const colSample As Integer = &HFFFF00 ' normally blue
	Public Const colTxtBox As Integer = &H80000005 ' normally white-ish
	
	
	Structure RecentStartEnquiry
		Dim strUniqueId As String
		Dim strProduct As String
		Dim strSerial As String
		Dim datStep3 As Date
		Dim strPottingSuccess As String
		Dim strFullDescription As String
		Dim strPottingShot As String
		Dim strScrapped As String
	End Structure
	
	Public Function ScreenResolution(ByRef f As System.Windows.Forms.Form) As String
		
		Dim iWidth, iHeight As Short
		
		iWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ VB6.TwipsPerPixelX
		iHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ VB6.TwipsPerPixelY
		ScreenResolution = iWidth & " X " & iHeight
		
	End Function
End Module