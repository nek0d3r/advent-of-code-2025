position = 50
zeroes = 0
print(f"The dial starts by pointing at {position}.")
with open("input1.txt") as file:
    lines = file.readlines()
    for line in lines:
        direction = line.strip()[0]
        value = int(line.strip()[1:])
        if direction == "L":
            position -= value
        if direction == "R":
            position += value
        while position < 0:
            position += 100
        position %= 100
        print(f"The dial is rotated {direction}{value} to point at {position}.")
        if position == 0:
            zeroes += 1
print(f"The password is {zeroes}")