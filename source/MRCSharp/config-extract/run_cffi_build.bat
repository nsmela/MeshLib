@echo [off]
title Script to convert h headers to ffi
echo running c2ffi
c2ffi extract --config config-mrbox.json
c2ffi extract --config config-mrmesh.json
pause