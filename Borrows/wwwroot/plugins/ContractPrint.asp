<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<%@ LANGUAGE="VBSCRIPT" %>
<HTML>
<HEAD>
<TITLE>KYOCERA Document Solutions</TITLE>
</HEAD>
<BODY BGCOLOR=C6C6C6 ONUNLOAD="CallDestroy();" leftmargin=0 topmargin=0 rightmargin=0 bottommargin=0>
<%
Dim ReportName
ReportName=Server.MapPath("report\Contracttest.rpt")

On Error Resume Next

'If Not IsObject ( session("oApp") ) Then
    Set session ("oApp") = Server.CreateObject("CrystalRuntime.Application.11")
	Session("oApp").LogonServer "crdb_odbc.dll", "db_server", "kyocera_db", "sa" , "g8gvH,mugv="
'End If

If IsObject(session("oRpt")) then
	Set session("oRpt") = nothing
End if
Set session("oRpt") = session("oApp").OpenReport(ReportName,1)
Session("oRpt").MorePrintEngineErrorMessages = false
session("oRpt").enableparameterprompting=false
session("oRpt").DiscardSavedData
'session("oRpt").RecordSelectionFormula=session("send1")
session("oRpt").RecordSelectionFormula="{ContractH.ContractID}="&Request("ContractID")

If Err.Number <> 0 Then
    Response.Write "An Error has occured. Please check the ASP page.<BR>"
    Response.Write "Error " & Err.number & " " & Err.description 
Else
    If IsObject(session("oPageEngine")) Then
        set session("oPageEngine") = nothing
    End If
    set session("oPageEngine") = session("oRpt").PageEngine
End If
%>
<OBJECT ID="CRViewer"
	CLASSID="CLSID:6F0892F7-0D44-41C3-BF07-7599873FAA04"
	WIDTH=100% HEIGHT=99%
	CODEBASE="/crystalreportviewers115/ActiveXControls/ActiveXViewer.cab#Version=11,5,0,261" VIEWASTEXT>
<PARAM NAME="EnableRefreshButton" VALUE=1>
<PARAM NAME="EnableGroupTree" VALUE=1>
<PARAM NAME="DisplayGroupTree" VALUE=1>
<PARAM NAME="EnablePrintButton" VALUE=1>
<PARAM NAME="EnableExportButton" VALUE=1>
<PARAM NAME="EnableDrillDown" VALUE=1>
<PARAM NAME="EnableSearchControl" VALUE=1>
<PARAM NAME="EnableAnimationControl" VALUE=1>
<PARAM NAME="EnableZoomControl" VALUE=1>
</OBJECT>

<SCRIPT LANGUAGE="VBScript">
<!--
Sub Window_Onload
	On Error Resume Next
	Dim webBroker
	Set webBroker = CreateObject("CrystalReports115.WebReportBroker.1")
	if err.number <> 0 then
		window.alert "The Crystal Report Viewer is unable to create its resource objects."
	elseif ScriptEngineMajorVersion < 2 then
		window.alert "IE 3.02 users on NT4 need to get the latest version of VBScript or install IE 4.01 SP1. IE 3.02 users on Win95 need DCOM95 and latest version of VBScript, or install IE 4.01 SP1. These files are available at Microsoft's web site."
	else
		Dim webSource
		Set webSource = CreateObject("CrystalReports115.WebReportSource.1")
		webSource.ReportSource = webBroker
		webSource.URL = "RDCrptserver115.asp"
		webSource.PromptOnRefresh = True
		CRViewer.ReportSource = webSource	
	end if
	CRViewer.ViewReport
	
End Sub
-->
</SCRIPT>

<%
'This page is used to clean up any Crystal Reports RDC Runtime objects remaining in a
'a user's session.  This page is called by a new browser window that is launched when
'a user closes a browser window containing a Crystal Reports viewer.

Function DestroyObjects(ByRef ObjectToDestroy)
  If isobject(ObjectToDestroy) then
    set ObjectToDestroy = nothing
    DestroyObjects = true
  Else
    DestroyObjects = false
  End if
End Function

DestroyObjects session("oPageEngine")
DestroyObjects session("oRpt")
DestroyObjects session("oApp")

'Session.Abandon
Response.End

%>
</BODY>
</HTML>

