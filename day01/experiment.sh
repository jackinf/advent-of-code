#!/bin/bash

start=`date +%s`

declare -A animals=( ["moo"]="cow" ["-123"]="dog")
echo "${animals[moo]}"
for sound in "${!animals[@]}"; do echo "$sound - ${animals[$sound]}"; done

woof=-123
if [[ ${animals["${woof}"]} =~ "dog" ]]; then
    echo "We have this animal"
fi

end=`date +%s`
runtime=$((end-start))
echo $runtime