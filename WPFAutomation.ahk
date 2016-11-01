class WPF
{
	SetText(window, component, text)
	{
		win := WPF.GetWindow(window)
		cmd = %A_ScriptDir%\ahks\WPFCmdAutomation.exe SetText "%win%" "%component%" "%text%"
		; MsgBox, %cmd%
		Run, %cmd%
	}
	
	GetWindow(window)
	{
		WinGetTitle, title, %window%
		result = %title%
		return result
	}
}