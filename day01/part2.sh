#!/bin/bash

# TODO: this is work in progress as I'm endlessly looping through the array

input="./input.txt"
declare -a CACHE

lastfreq=0
found=0
while true; do
  while IFS= read -r value
  do  
    sum=$(($lastfreq+$value))
    echo "$lastfreq + $value -> $(($sum))"
     if [[ " ${CACHE[@]} " =~ " ${sum} " ]]; then
      echo "Found: $sum"
      found=1
      break
    else
      CACHE+=($sum)
      lastfreq=$sum
    fi
  done < "$input"
  if [[ $found =~ 1 ]]; then
    break
  fi
done
