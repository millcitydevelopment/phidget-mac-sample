#!/bin/bash

#--- This script must be executed from the project folder (where the .csproj file is located for mac)
echo '---------Fixing Xamarin bundling symlink bug https://github.com/xamarin/xamarin-macios/issues/5213'

cd bin/Release/RoastPath.app/Contents/Frameworks/Phidget22.framework
rm Phidget22
ln -s Versions/Current/Phidget22 Phidget22
ln -s Versions/Current/_CodeSignature _CodeSignature

echo '---------Xmarin symlink bug fixed'
