# Change

- Updated project to .NET 6. It because deprecation of .NET 5 by GitHub Actions.
  - CSV Parser itself has same prerequisites as before.

# Fix

- Fixed a bug that last cell will be ignored when single cell rows not ending with CRLF. (Thank you so much @gmichaudAniki !)

# Misc. Changes

- Fixed some errors in README.

- Updated CI to compliant with Node.js 16.