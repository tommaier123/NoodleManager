if "%~1"=="" goto blank
if "%~2"=="" goto blank
adb push %1 sdcard/SynthRidersUC%2

:blank