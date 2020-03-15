if "%~1"=="" goto blank
if "%~2"=="" goto blank
adb push %1 sdcard/Android/data/com.kluge.SynthRiders/files%2
:blank