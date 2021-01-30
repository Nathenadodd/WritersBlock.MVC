# WritersBlock.MVC
Writer’s Block-Red Badge ReadMe


Writer’s Block is a shared workspace where self-publishing writers can work together to edit and proof-read their work. Unfortunately, having a talent for writing does not make a person an editor. By the same token, not everyone can afford to pay an editor to go through their projects. At Writer’s Block we want to bring together like-minded people in a positive, encouraging community that is conducive to completing your best work.

As an author who intends to self-publish it would be nice to have a place to turn to like-minded people who want to help each other. I have read multiple works on the internet that had a lot of potential, but were lacking basic editing that distracted from the story the author was trying to tell.

Writer’s Block is designed to make editing your own work a less stressful process and provide more sets of eyes to review. It can be used to post snippets of your work that others can then comment on to help.

By Registering and logging in a User will have access to all of the available options.
If the User goes to Post, they can create a post and post it. There are also options to Edit or Delete that post and view the Details of when it was published.

In Comments Users can select a post to comment on and Edit, or Delete those comments as well as view the details of the Comment.

In Faves the User can favorite a post and comment that they found especially interesting or useful. 


Writer’s Block Currently consists of three Data Tables that are structured as follows:

Table 1-Post
PK PostID int
FK UserID int
PostText string
CreatedUTC DateTimeOffset
ModifiedUTC DateTimeOffset


Table 2-Comments
PK CommentID int
FK UserID
FK PostID int
R CommentText string
CreatedUTC DateTimeOffset
ModifiedUTC DateTimeOffset

Table 3-Faves
PK FaveID int
FK UserID
FK PostID int
FK CommentID int
CreatedUTC DateTimeOffset
ModifiedUTC DateTimeOffset

Setup

Data Layer
Posts
Comments
Faves
Identity Models

Models
CommentCreate
CommentDetail
CommentEdit
CommentListItem
FaveCreate
FaveListItem
FavesEdit
FavesDetail
PostCreate
PostDetail
PostEdit
PostListItem

Services
PostService
CommentService
FavesService

Controllers
CommentController
FavesController
PostController

Views
Comment
Create.cshtml
Delete.cshtml
Details.cshtml
Edit.cshtml
Index.cshtml
Faves
Create.cshtml
Delete.cshtml
Details.cshtml
Edit.cshtml
Index.cshtml

Post
Create.cshtml
Delete.cshtml
Details.cshtml
Edit.cshtml
Index.cshtml


Version 1.0 / MVP
Users can post content for advice
Users can comment/offer advice
User can register and login
Create a new post
Reply to comment
Favorite a  post
Favorite a comment


Version 2.0 / Stretch Goals
Translation services
Archive
Chat option
Post full work
Users can link to their fave users
Future Goals Include:
The ability to favorite and Link to a User
Private Chats between Users that would like to collaborate
Translation services for Authors publishing in an unfamiliar language
Help with slang for other languages
Capacity to post full work


Actively Working On:
A more pleasing CSS 



Contact:
Nathena Dodd 
nathenadodd@gmail.com

©2021 Writer’s Block








