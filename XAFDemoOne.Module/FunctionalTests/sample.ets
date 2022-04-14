;#DropDB XAFDemoOneEasyTest

#Application XAFDemoOneWin
;#Application XAFDemoOneWeb
#IfDef XAFDemoOneWin

*Action About...
 
*Action OK

#EndIf

#IfDef XAFDemoOneWeb
!Action Navigation(My Details)
#EndIf
