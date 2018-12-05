#!/bin/bash

function printme {
  return # mute all the messages. Remove for debugging.
  echo $1
}

input="./input.txt"
twos=0
threes=0
one=1
while IFS= read -r line
do
  # Break word into array of characters using grep, then sort for some unknown reason and group using uniq -c
  my_array=( $(echo $line | grep -o . | sort | uniq -c) )
  
  # display all elements
  printme ${my_array[@]}

  found_two=0
  found_three=0
 
  # loop through all elements
  for item in "${my_array[@]}"
  do
    if [[ $item = 2 && $found_two = 0 ]]; then
      found_two=1
      twos=$(($twos+$one))
    fi

    if [[ $item = 3 && $found_three = 0 ]]; then
      found_three=1
      threes=$(($threes+$one))
    fi
  done

  printme "Two: $found_two, Three: $found_three"
done < "$input"

echo "Result: $(($twos*$threes))"