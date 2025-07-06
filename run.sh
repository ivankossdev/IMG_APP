#!/bin/bash

rm example/*.bmp
rm example/*.txt
rm test_ex/*.txt

clear
if [[ "py" == "$1" ]]
    then
        python3 bmp.py
    else
        dotnet run app
fi