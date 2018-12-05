#!/bin/bash

start=`date +%s`

input="./input.txt"
declare -A CACHE=()

lastfreq=0
found=0
while true; do
  while IFS= read -r value
  do  
    sum=$(($lastfreq+$value))
    # echo "$lastfreq + $value -> $(($sum))" # Printing is costly
    if [[ ${CACHE["${sum}"]} =~ 1 ]]; then
      echo "Found: $sum"
      found=1
      break
    else
      CACHE["${sum}"]=1
      lastfreq=$sum
    fi
  done < "$input"
  if [[ $found =~ 1 ]]; then
    break
  fi
done

end=`date +%s`
runtime=$((end-start))
echo $runtime