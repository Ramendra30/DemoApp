Pushd "c:\ram"
FOR /F "delims=" %%G IN ('dir /TW /OD *.txt') do SET "filedate=%%~tG"
popd