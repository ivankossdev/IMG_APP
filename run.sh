#!/bin/bash

clear
if [[ "py" == "$1" ]]
    then
        python3 bmp.py
    else
        dotnet run app
fi