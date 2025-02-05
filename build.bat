@echo off
echo Installing Node...
nvm install 18 
nvm use 18
echo Building Frontend...
cd frontend 
start /wait cmd /c "npm install --force && npm run build"
echo Building Backend...
cd ../API 
dotnet publish -c Release -o ../dist/api
cd ../../