#!/bin/bash

clear
if [[ "py" == "$1" ]]
    then
        python3 bmp.py
    else
        rm example/*.bmp
        rm example/*.txt
        rm test_ex/*.txt
        dotnet run app
fi