#!/bin/bash
input="./input.txt"
sum=0
while IFS= read -r var
do
  sum=$(($sum + $var))
done < "$input"
echo $sum
