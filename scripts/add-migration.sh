#!/bin/bash

# Check if migration name is provided
if [ -z "$1" ]; then
    echo "Usage: ./scripts/add-migration.sh <MigrationName>"
    echo "Example: ./scripts/add-migration.sh AddUserTable"
    exit 1
fi

# Navigate to API project and run the migration command
cd FlockWise.API
dotnet ef migrations add "$1" --project ../FlockWise.Infrastructure