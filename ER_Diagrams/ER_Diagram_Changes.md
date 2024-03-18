# A. Consolidation

- Removing route and packet from entity 'Deliveries', because they seem redundant.
- Adding delivery_place to entity 'Orders', as this is mentioned by the manager in assignment 2. 
- Agreeing on the multiplicity 1-to-N from 'Orders' to 'Deliveries', in order to get multiple track-id's from deliveries. 
- Agreed on having location in entity 'Deliveries'
- Agreed to have quantities in entity 'BakingGoods'
- Agreed on removing recipe from 'BakingGoods'
- Agreed on adding price to 'BakingGoods'
- Agreed on having N-to-N multiplicity from 'Batches' to 'Ingredients'
- Agreed on having three times (scheduledFinishTime, StartTime, and FinishTime) on entity 'Batches' in order to be able to calculate the delay. 
- Agreed on N-to-N multiplicity from 'BakingGoods' to 'Batches'
- Agreed on having an ID on entity 'Ingredients'
- Agreed on changing attribute stock to quantity in entity 'Ingredients'
- Agreed on creating attribute 'Address' as normal attribute instead of a composite attribute.

Generally the ER diagram has been cut to the bone, to focus on the essentials of the system, the customer is requesting. 

