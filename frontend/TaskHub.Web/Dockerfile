# Use a lightweight Node.js image
FROM node:20-alpine

# Set the working directory inside the container
WORKDIR /app

# Copy dependency declarations
COPY package*.json ./

# Install node modules
RUN npm install

# Copy all project files
COPY . .

# Expose default Angular dev server port
EXPOSE 4200

# Start Angular dev server with hot reload enabled
CMD ["npm", "run", "start"]
