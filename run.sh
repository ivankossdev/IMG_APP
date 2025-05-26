#!/bin/bash

rm example/*.bmp
rm example/*.txt

clear
if [[ "py" == "$1" ]]
    then
        python3 bmp.py
    else
        dotnet run app
fi