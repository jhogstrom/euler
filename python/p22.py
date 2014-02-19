def value(s):
	return sum([1 + ord(c) - ord('A') for c in s])

names,i, d, total = sorted(open(r"c:\temp\names.txt").readline().strip().replace('"', "").split(",")), 1, {}, 0
for i in range(len(names)):
	total += value(names[i]) * (i + 1)
print total
