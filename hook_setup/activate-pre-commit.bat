@echo off

REM Copy pre-commit file to .git/hooks directory
copy /Y pre-commit ..\.git\hooks\pre-commit

REM Make the pre-commit file executable
icacls ..\.git\hooks\pre-commit /grant Everyone:RX

echo Pre-commit hook has been activated.