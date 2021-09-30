import pandas as pd
import matplotlib.pyplot as plt

csv_file='outfile1.csv'
data = pd.read_csv(csv_file)

x=list(data.iloc[:, 0])
y=list(data.iloc[:, 1])

plt.figure(figsize=(15,7))
plt.scatter(x, y, s=1)
plt.xlabel('$\delta$')
plt.ylabel('$x_n$')
plt.title('Predator-Prey Bifurcation Diagram')
plt.savefig('predprey_bifurcation.jpeg')
plt.show()
