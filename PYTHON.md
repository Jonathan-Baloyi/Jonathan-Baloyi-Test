Here’s a simple Flask API with a SQL database that includes two endpoints: one to get a list of jobs (`GET /jobs`) and another to add a job (`POST /add_job`). We will use SQLite for the SQL database, which is easy to set up for demonstration purposes.

### Setting up the Flask API

1. Install the necessary packages:
   ```bash
   pip install flask sqlalchemy
   ```

2. Create a `app.py` file with the following content:

```python
from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy

# Initialize the Flask app
app = Flask(__name__)

# Configuring the SQLite database
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///jobs.db'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

# Initialize the SQLAlchemy ORM
db = SQLAlchemy(app)

# Define the Job model
class Job(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    title = db.Column(db.String(100), nullable=False)
    description = db.Column(db.String(200), nullable=False)

    def to_dict(self):
        return {"id": self.id, "title": self.title, "description": self.description}

# Endpoint to get all jobs
@app.route('/jobs', methods=['GET'])
def get_jobs():
    jobs = Job.query.all()
    return jsonify([job.to_dict() for job in jobs])

# Endpoint to add a job
@app.route('/add_job', methods=['POST'])
def add_job():
    data = request.json
    title = data.get('title')
    description = data.get('description')
    
    if not title or not description:
        return jsonify({"error": "Title and description are required"}), 400

    new_job = Job(title=title, description=description)
    db.session.add(new_job)
    db.session.commit()
    
    return jsonify({"message": "Job added successfully", "job": new_job.to_dict()}), 201

# Initialize the database and create the tables
@app.before_first_request
def create_tables():
    db.create_all()

# Run the Flask app
if __name__ == '__main__':
    app.run(debug=True)
```

### Explanation:

1. **Database Setup:**
   - We're using `SQLAlchemy` to interact with the SQLite database.
   - A `Job` model is defined with two fields: `title` and `description`.

2. **GET /jobs Endpoint:**
   - This endpoint retrieves all jobs from the database.
   - It returns a JSON array of jobs.

3. **POST /add_job Endpoint:**
   - This endpoint adds a new job to the database.
   - It expects a JSON payload with `title` and `description`.
   - If the required fields are missing, it returns an error response.
   - If successful, it saves the job and returns a confirmation message along with the job details.

### Example API Requests:

- **GET /jobs**:
   ```bash
   curl -X GET http://127.0.0.1:5000/jobs
   ```

- **POST /add_job**:
   ```bash
   curl -X POST http://127.0.0.1:5000/add_job \
   -H "Content-Type: application/json" \
   -d '{"title": "Software Engineer", "description": "Develop web applications"}'
   ```

This will create a simple Flask API with SQLite that can handle job listings.
